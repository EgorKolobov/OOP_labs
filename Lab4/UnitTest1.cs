using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using Lab4;
namespace Lab4Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var fileA = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileB.txt");
            var fileB = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileA.txt");
            
            var backup = new Backup();
            backup.Add(fileA);
            backup.Add(fileB);
            
            backup.MakeFullRestorePoint(); // 2 BackupFiles, 1 RestorePoint
            
            Assert.AreEqual(2, backup.RestorePoints[0].FilesCount);
            
            backup.MakeFullRestorePoint();
            
            backup.AddLimit(new NumberLimit(1));
            backup.PushItToTheLimit();
            
            Assert.AreEqual(1, backup.RestorePoints.Count);
        }

        [Test]
        public void Test2()
        {
            var file50A = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/File50A.txt");
            var file50B = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/File50B.txt");

            var backup = new Backup(new List<BackupFile>(){file50A, file50B});
            
            backup.MakeFullRestorePoint();
            Assert.AreEqual(2,backup.RestorePoints.Count);
            Assert.AreEqual(200, backup.Size);
            
            backup.AddLimit(new MemoryLimit(150));
            backup.PushItToTheLimit();
            
            Assert.AreEqual(1,backup.RestorePoints.Count);
        }

        [Test]
        public void Test3()
        {
            var fileA = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileB.txt");
            var fileB = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileA.txt");
            var fileC = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileA.txt");
            
            var backup = new Backup(new List<BackupFile>(){fileA, fileB}); // 2 files, 1 RestorePoint
            
            backup.Add(fileC); 
            
            backup.MakeDeltaRestorePoint(); // 3 files, 2 RestorePoint
            Assert.AreEqual(2, backup.RestorePoints.Count);
            
            backup.AddLimit(new TimeLimit(DateTime.Now));
            
            backup.MakeFullRestorePoint();// 3 files, 1 RestorePoint
            Assert.AreEqual(1, backup.RestorePoints.Count);
        }

        [Test]
        public void Test4()
        {
            
            var fileA = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileB.txt");
            var fileB = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileA.txt");
            var fileC = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileA.txt");
            
            var backup = new Backup(new List<BackupFile>(){fileA}); // 1 files, Size 1

            var nLim = new NumberLimit(3);
            var memLim = new MemoryLimit(6);
            
            backup.Add(fileB);
            backup.MakeFullRestorePoint(); // 2 files, Size 2
            
            backup.Add(fileC);
            backup.MakeFullRestorePoint(); // 3 files, Size 3

            Thread.Sleep(500);
            var tLim = new TimeLimit(DateTime.Now);
            Thread.Sleep(500);
            
            backup.MakeFullRestorePoint(); // 3 files, Size 3
            // Backup: 3 files, 4 RestorePoint, total size 9
            backup.AddLimit(nLim);
            backup.AddLimit(memLim);
            backup.AddLimit(tLim);
            backup.PushItToTheLimit();
            Assert.AreEqual(3, backup.RestorePoints.Count);
        }

        [Test]
        public void Test5()
        {
            var fileA = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileB.txt");
            var fileB = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileA.txt");
            var fileC = new BackupFile("/Users/egorius/Desktop/Homework/OOP/Labs/Lab4/Lab4/FileA.txt");
            
            var backup = new Backup();
            backup.AddLimit(new NumberLimit(2));
            
            backup.Add(fileA);
            backup.MakeFullRestorePoint();
            
            backup.Add(fileA);
            backup.MakeDeltaRestorePoint();
            
            backup.Add(fileC);
            try
            {
                backup.MakeFullRestorePoint();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Number Limit: Can't leave delta point without restore point.", e.Message);
            }
        }

    }
}