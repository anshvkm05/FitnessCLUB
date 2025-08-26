using NUnit.Framework;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace FitnessCLUB.Tests
{
    [TestFixture]
    public class TestLoginUser
    {
        private LoginUser loginUser;

        [SetUp]
        public void Setup()
        {
            // Typically, you'd pass a mock or dummy form to the constructor.
            Login_user dummyForm = new Login_user();
            loginUser = new LoginUser(dummyForm);

            // Clear or reset any static dictionaries before each test
            ClearStaticDictionaries();
        }

        [Test]
        public void Test_ValidLoginCredentials()
        {
            MethodInfo resetMethod = typeof(LoginUser).GetMethod("ResetFailedAttempts", BindingFlags.NonPublic | BindingFlags.Instance);
            resetMethod.Invoke(loginUser, new object[] { "testUser" });
            Dictionary<string, int> faDict = GetFailedAttemptsDictionary();
            faDict["testUser"] = 2; 
            resetMethod.Invoke(loginUser, new object[] { "testUser" });
            Assert.That(faDict["testUser"], Is.EqualTo(0), "Failed attempts should be 0 after successful login reset.");
        }

        [Test]
        public void Test_InvalidCredentials_IncrementFailedAttempts()
        {
            Dictionary<string, int> faDict = GetFailedAttemptsDictionary();
            MethodInfo incMethod = typeof(LoginUser).GetMethod("IncrementFailedAttempts", BindingFlags.NonPublic | BindingFlags.Instance);
            incMethod.Invoke(loginUser, new object[] { "testUser" });
            incMethod.Invoke(loginUser, new object[] { "testUser" });
            incMethod.Invoke(loginUser, new object[] { "testUser" });
            Assert.That(faDict["testUser"], Is.EqualTo(3), "Should be 3 failed attempts after 3 invalid logins.");
        }

        [Test]
        public void Test_AccountLock_AfterThreeFails()
        {
            Dictionary<string, bool> lockedDict = GetAccountLockedDictionary();
            MethodInfo incMethod = typeof(LoginUser).GetMethod("IncrementFailedAttempts", BindingFlags.NonPublic | BindingFlags.Instance);
            incMethod.Invoke(loginUser, new object[] { "testUser" });
            incMethod.Invoke(loginUser, new object[] { "testUser" });
            incMethod.Invoke(loginUser, new object[] { "testUser" });
            Assert.That(lockedDict["testUser"], Is.True, "Account should be locked after 3 invalid attempts.");
        }
        private void ClearStaticDictionaries()
        {
            var faDict = GetFailedAttemptsDictionary();
            var acDict = GetAccountLockedDictionary();
            faDict.Clear();
            acDict.Clear();
        }

        private Dictionary<string, int> GetFailedAttemptsDictionary()
        {
            FieldInfo field = typeof(LoginUser).GetField("failedAttempts", BindingFlags.NonPublic | BindingFlags.Static);
            return (Dictionary<string, int>)field.GetValue(null);
        }

        private Dictionary<string, bool> GetAccountLockedDictionary()
        {
            FieldInfo field = typeof(LoginUser).GetField("accountLocked", BindingFlags.NonPublic | BindingFlags.Static);
            return (Dictionary<string, bool>)field.GetValue(null);
        }
    }
}