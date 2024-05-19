using UserDomain.ControlModule.Interfaces;
using UserDomain.ControlModule;
using UserDomain.model;
using UserDomain.Model;
using System.Security.Cryptography.X509Certificates;
using UserDomain.Properties;
using System.Reflection;

namespace TestCompetitionLibraries
{
    public class Tests
    {
        private IUserManager userMaster = new UserManager();
        private PrimeUser expectedUser;
        private PrimeUser belkarUser;
        private Guid falseUserGuid;
        private PrimeUser getUser;
        private Guid secondValidGuid;
        private PrimeUser newUser;
        private PrimeUser archiveUser;
        private PrimeUser incorrectNewUser;
        private PrimeUser duplicateNewUser;

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            // fixture one time setup code, can use await here
            // load and create users
            await userMaster.GenerateTestUsers();
        }

        [SetUp]
        public void Setup()
        {


            // generate user for manipulation
            expectedUser = new PrimeUser
            {
                Status = UserDomain.Properties.USER_STATUS.ACTIVE,
                Code = "TST0000001",
                Name = "Roy Greenhilt",
                Id = new Guid("6269941b-58ec-4f3a-bd4c-98b94fae3fc6"),
                Tag = "Speedbump",
                ThumbnailUrl = "http://www.gravatar.com/avatar/e365b9c6ee6e24cb5e7162ba21c149c3?d=wavatar&s=100"
            };

            getUser = new PrimeUser
            {
                Status = UserDomain.Properties.USER_STATUS.ACTIVE,
                Code = "TST0000004",
                Name = "Durkon Thundershield",
                Id = new Guid("82586fc2-6aee-4aaa-972e-b007cf5edc32"),
                Tag = "Dour",
                ThumbnailUrl = "http://www.gravatar.com/avatar/454c9843110686bf6f67ce5115b66617?d=wavatar&s=100"
            };

            belkarUser = new PrimeUser
            {
                Status = UserDomain.Properties.USER_STATUS.ACTIVE,
                Code = "TST0000002",
                Name = "Belkar Bitterleaf",
                Id = new Guid("84c8cb7a-28c2-4ed7-b4f6-1620b09898f7"),
                Tag = "Pocket of Rage",
                ThumbnailUrl = "http://www.gravatar.com/avatar/e365b9c6ee6e24cb5e7162ba21c149c3?d=wavatar&s=100"
            };

            duplicateNewUser = new PrimeUser
            {
                Status = UserDomain.Properties.USER_STATUS.ACTIVE,
                Code = "TST0000005",
                Name = "Not Belkar",
                Id = new Guid("8269941b-58ec-4f3a-bd4c-98b94fae3fc6"),
                Tag = "Ranger",
                ThumbnailUrl = "http://www.gravatar.com/avatar/e365b9c6ee6e24cb5e7162ba21c149c3?d=wavatar&s=100"
            };

            incorrectNewUser = new PrimeUser
            {
                Status = UserDomain.Properties.USER_STATUS.ACTIVE,
                Code = "TST0000050",
                Name = "Clare Walters",
                Id = new Guid("6369941b-58ec-4f3a-bd4c-98b94fae3fc6"),
                Tag = "Speedbump",
                ThumbnailUrl = "http://www.gravatar.com/avatar/e365b9c6ee6e24cb5e7162ba21c149c3?d=wavatar&s=100"
            };



            newUser = new PrimeUser
            {
                Status = UserDomain.Properties.USER_STATUS.ACTIVE,
                Code = "TST0000007",
                Name = "Bob Round",
                Id = new Guid("7769941b-58ec-4f3a-bd4c-98b94fae3fc6"),
                Tag = "Balloon",
                ThumbnailUrl = "http://www.gravatar.com/avatar/502dd302b6d8d3c24b20ee49e2d51bd1?d=monsterid&s=100"
            };

            archiveUser = new PrimeUser
            {
                Status = UserDomain.Properties.USER_STATUS.ACTIVE,
                Code = "TST0000002",
                Name = "Haley Starshine",
                Id = new Guid("84c8cb7a-28c2-4ed7-b4f6-1620b09898f7"),
                Tag = "Redhead",
                ThumbnailUrl = "http://www.gravatar.com/avatar/821e09c59f7f85ea87d19a0c05e40403?d=wavatar&s=100"
            };

            falseUserGuid = new Guid("6269941b-58ec-4f3a-bd4c-98b94fae3fc7");
            secondValidGuid = new Guid("84c8cb7a-28c2-4ed7-b4f6-1620b09898f7");
        }

        #region Get Tests
        [Test]
        public void TestGetAllUsers()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());
            PrimeUserCollection allUsers = userMaster.GetAllActiveUsers().Result;


            Assert.That(allUsers, Is.Not.Null, $"{methodNme} should not return null");
            Assert.That(allUsers, Has.Count.GreaterThan(3), $"{methodNme} has returned {allUsers.Count} records and should return 4 or more with the test data");

            
        }

        [Test]
        public void GetSpecificExistingUserTag()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());


            Task<PrimeUser?> usrResultTask = userMaster.GetUserFromTag(getUser.Tag);

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;

                Assert.That(testUserFound, Is.Not.Null, $"{methodNme} should not return null when User Exists");
                Assert.Multiple(() =>
                {
                    Assert.That(testUserFound.Name, Is.EqualTo(getUser.Name), $"{methodNme} should return '{getUser.Name}' but is returning {testUserFound.Name}");
                    Assert.That(testUserFound.Tag, Is.EqualTo(getUser.Tag), $"{methodNme} should return '{getUser.Tag}' but is returning {testUserFound.Tag}");
                    Assert.That(testUserFound.Code, Is.EqualTo(getUser.Code), $"{methodNme} should return '{getUser.Code}' but is returning {testUserFound.Code}");
                    Assert.That(testUserFound.Id, Is.EqualTo(getUser.Id), $"{methodNme} should return '{getUser.Id}' but is returning {testUserFound.Id}");
                    Assert.That(testUserFound.Status, Is.EqualTo(getUser.Status), $"{methodNme} should return '{getUser.Status}' but is returning {testUserFound.Status}");
                });
            }
            else
            {
                Assert.Fail();// no result should fail
            }
        }

        [Test]
        public void GetNonExistantUserFromTag()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());

            Task<PrimeUser?> usrResultTask = userMaster.GetUserFromCode("zeitgeist299999");

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;

                Assert.Multiple(() =>
                {
                    Assert.That(testUserFound, Is.Not.Null, $"{methodNme} should not return null even when code is invalid");
                    Assert.That(actual: testUserFound, Is.Empty, $"{methodNme} has returned record for {testUserFound.Name} when should return 0 records records");
                });
            }
        }

        [Test]
        public void GetSpecificExistingUserCode()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());


            Task<PrimeUser?> usrResultTask = userMaster.GetUserFromCode(getUser.Code);

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;

                Assert.That(testUserFound, Is.Not.Null, $"{methodNme} should not return null when User Exists");
                Assert.Multiple(() =>
                {
                    Assert.That(testUserFound.Name, Is.EqualTo(getUser.Name), $"{methodNme} should return '{getUser.Name}' but is returning {testUserFound.Name}");
                    Assert.That(testUserFound.Tag, Is.EqualTo(getUser.Tag), $"{methodNme} should return '{getUser.Tag}' but is returning {testUserFound.Tag}");
                    Assert.That(testUserFound.Code, Is.EqualTo(getUser.Code), $"{methodNme} should return '{getUser.Code}' but is returning {testUserFound.Code}");
                    Assert.That(testUserFound.Id, Is.EqualTo(getUser.Id), $"{methodNme} should return '{getUser.Id}' but is returning {testUserFound.Id}");
                    Assert.That(testUserFound.Status, Is.EqualTo(getUser.Status), $"{methodNme} should return '{getUser.Status}' but is returning {testUserFound.Status}");
                });
            }
            else
            {
                Assert.Fail();// no result should fail
            }
        }

        [Test]
        public void GetNonExistantUserFromCode()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());

            Task<PrimeUser?> usrResultTask = userMaster.GetUserFromCode("zeitgeist299999");

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;

                Assert.Multiple(() =>
                {
                    Assert.That(testUserFound, Is.Not.Null, $"{methodNme} should not return null even when code is invalid");
                    Assert.That(actual: testUserFound, Is.Empty, $"{methodNme} has returned record for {testUserFound.Name} when should return 0 records records");
                });
            }
        }

        [Test]
        public void GetSpecificUserFromGuid()
        {
            Task<PrimeUser> usrResultTask = userMaster.GetUserFromGuid(getUser.Id);

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;
                string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());
                Assert.Multiple(() =>
                {
                    Assert.That(testUserFound, Is.Not.Null, $"{methodNme} should not return null when User Exists");
                });
                Assert.That(testUserFound.Name, Is.EqualTo(getUser.Name), $"{methodNme} should return '{getUser.Name}' but is returning {testUserFound.Name}");
                Assert.Multiple(() =>
                {
                    Assert.That(testUserFound.Tag, Is.EqualTo(getUser.Tag), $"{methodNme} should return '{getUser.Tag}' but is returning {testUserFound.Tag}");
                    Assert.That(testUserFound.Code, Is.EqualTo(getUser.Code), $"{methodNme} should return '{getUser.Code}' but is returning {testUserFound.Code}");
                    Assert.That(testUserFound.Id, Is.EqualTo(getUser.Id), $"{methodNme} should return '{getUser.Id}' but is returning {testUserFound.Id}");
                    Assert.That(testUserFound.Status, Is.EqualTo(getUser.Status), $"{methodNme} should return '{getUser.Status}' but is returning {testUserFound.Status}");
                });

            }
            else
            {
                Assert.Fail();// no result should fail
            }
        }

        [Test]
        public void GetNonExistantUserFromGuid()
        {
            Task<PrimeUser> usrResultTask = userMaster.GetUserFromGuid(falseUserGuid);

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;
                string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());

                Assert.That(testUserFound, Is.Not.Null, $"{methodNme} GetNonExistantUser should not return null even when code is invalid");
                Assert.That(testUserFound, Is.Empty, $"{methodNme} has returned record for {testUserFound.Name} when it should return a 0 records");
            }
            else
            {
                Assert.Pass();// no result which is entirely expected
            }

        }
        #endregion Get Tests

        #region CRUD tests
        [Test]
        public void CreateUser()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());
            string createStatus = userMaster.CreateUser(newUser).Result;

            Assert.That(createStatus, Is.Empty, $"{methodNme} Create User should not generate any issues for a clean record");

            // then GET that user from the db
            Task<PrimeUser> usrResultTask = userMaster.GetUserFromGuid(newUser.Id);

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;

                Assert.That(testUserFound, Is.Not.Null, $"{methodNme} should not return null when User Exists");
               
                Assert.Multiple(() =>
                {
                    Assert.That(testUserFound.Name, Is.EqualTo(newUser.Name), $"{methodNme} should return '{newUser.Name}' but is returning {testUserFound.Name}");
                    Assert.That(testUserFound.Tag, Is.EqualTo(newUser.Tag), $"{methodNme} should return '{newUser.Tag}' but is returning {testUserFound.Tag}");
                    Assert.That(testUserFound.Code, Is.EqualTo(newUser.Code), $"{methodNme} should return '{newUser.Code}' but is returning {testUserFound.Code}");
                    Assert.That(testUserFound.Id, Is.EqualTo(newUser.Id), $"{methodNme} should return '{newUser.Id}' but is returning {testUserFound.Id}");
                    Assert.That(testUserFound.Status, Is.EqualTo(newUser.Status), $"{methodNme} should return '{newUser.Status}' but is returning {testUserFound.Status}");
                });

                

            }
            else Assert.Fail();// no response and this should work
            
        }

        [Test]
        public void DeleteUser()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());
            string deleteStatus = userMaster.DeleteUser(newUser).Result;

            Assert.That(deleteStatus, Is.Empty, $"{methodNme} Delete User should not generate any issues for a clean record");

            // then GET that user from the db
            Task<PrimeUser> usrResultTask = userMaster.GetUserFromGuid(newUser.Id);

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;
                Assert.That(testUserFound, Is.Null, $"{methodNme} should  return null after a delete");

            }

        }

        [Test]
        public void CreateDuplicateUser()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());


            string duplicateStatus = userMaster.CreateUser(duplicateNewUser).Result;

            Assert.That(duplicateStatus, Is.Not.Empty, $"{methodNme} Creating a duplicate User should  generate an invalid status code");
            Assert.Pass();
        }

        [Test]
        public void ArchiveUser()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());
            string createStatus = userMaster.ArchiveUser(archiveUser).Result;

            Assert.That(createStatus, Is.Empty, $"{methodNme} Archive User should not generate any issues for a clean record");

            Task<PrimeUser> usrResultTask = userMaster.GetUserFromGuid(archiveUser.Id);

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;

                Assert.That(testUserFound, Is.Not.Null, $"{methodNme} should return null when User has been removed from live table");
            }
            else
            {
                // record should not still be in a live table but should exist in Archive tables
                // TODO still need to link collections so searches can also check archive tables if relevant user not found
                Task<ArchiveUser?> archiveResultTask = userMaster.GetArchiveUserFromCode(archiveUser.Code);

                if (usrResultTask != null && usrResultTask.Result != null)
                {
                    PrimeUser testUserFound = usrResultTask.Result;

                    Assert.That(testUserFound, Is.Not.Null, $"{methodNme} should not return null when User Exists");
                    Assert.Multiple(() =>
                    {
                        Assert.That(testUserFound.Name, Is.EqualTo(archiveUser.Name), $"{methodNme} should return '{expectedUser.Name}' but is returning {testUserFound.Name}");
                        Assert.That(testUserFound.Tag, Is.EqualTo(archiveUser.Tag), $"{methodNme} should return '{expectedUser.Tag}' but is returning {testUserFound.Tag}");
                        Assert.That(testUserFound.Code, Is.EqualTo(archiveUser.Code), $"{methodNme} should return '{expectedUser.Code}' but is returning {testUserFound.Code}");
                        Assert.That(testUserFound.Id, Is.EqualTo(archiveUser.Id), $"{methodNme} should return '{expectedUser.Id}' but is returning {testUserFound.Id}");
                        Assert.That(testUserFound.Status, Is.EqualTo(archiveUser.Status), $"{methodNme} should return '{expectedUser.Status}' but is returning {testUserFound.Status}");
                    });
                }
            }
              

        }

        [Test]
        public void UpdateUserValid()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());
            // change the archive user non key fields

            expectedUser.Code = "TST0000033";
            
            string updateStatus = userMaster.UpdateUser(expectedUser).Result;

            Assert.That(updateStatus, Is.Empty, $"{methodNme} Update User should not generate any issues for a valid record");

            Task<PrimeUser> usrResultTask = userMaster.GetUserFromGuid(expectedUser.Id);

            if (usrResultTask != null && usrResultTask.Result != null)
            {
                PrimeUser testUserFound = usrResultTask.Result;
                Assert.That(testUserFound, Is.Not.Null, $"{methodNme} should not return null when User Exists");

                Assert.Multiple(() =>
                {

                    Assert.That(testUserFound.Name, Is.EqualTo(expectedUser.Name), $"{methodNme} should return '{expectedUser.Name}' but is returning {testUserFound.Name}");
                    Assert.Multiple(() =>
                    {
                        Assert.That(testUserFound.Tag, Is.EqualTo(expectedUser.Tag), $"{methodNme} should return '{expectedUser.Tag}' but is returning {testUserFound.Tag}");
                        Assert.That(testUserFound.Code, Is.EqualTo(expectedUser.Code), $"{methodNme} should return '{expectedUser.Code}' but is returning {testUserFound.Code}");
                        Assert.That(testUserFound.Id, Is.EqualTo(expectedUser.Id), $"{methodNme} should return '{expectedUser.Id}' but is returning {testUserFound.Id}");
                    });
                });
            }
            else Assert.Fail();
        }

        [Test]
        public void UpdateUserInValid()
        {
            string methodNme = GetMethodName(System.Reflection.MethodBase.GetCurrentMethod());
            

            string updateStatus = userMaster.UpdateUser(incorrectNewUser).Result;

            Assert.That(updateStatus, !Is.Empty, $"{methodNme} Update Invalid User should generate an issue");


        }

        

        #endregion CRUD tests

        #region Support Methods
        private string GetMethodName(MethodBase? possibleMethodName)
        {
            string result = "Test Method";


            if (possibleMethodName != null)
            {
                if(possibleMethodName.Name != null) result = possibleMethodName.Name;
            }


            return result;
        }
        #endregion Support Methods
    }
}