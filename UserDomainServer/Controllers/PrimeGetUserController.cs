using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServerCommonModule.Database;
using ServerCommonModule.Database.Interfaces;
using UserDomain.ControlModule;
using UserDomain.ControlModule.Interfaces;
using UserDomain.model;
using UserDomain.Model;
using UserDomainServer.Security;
using UserDomainServer.Security.Exceptions;

namespace UserDomainServer.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class PrimeGetUserController : ControllerBase
    {
        private readonly ILogger<PrimeGetUserController> _logger;
        private readonly IEnvironmentalParameters _environmentalParameters;
        private readonly IDbUtilityFactory _dbUtilityFactory;

        private IUserManager userManager = new UserManager();

        public PrimeGetUserController(ILogger<PrimeGetUserController> logger, IOptionsMonitor<EnvironmentalParameters> envParams, IDbUtilityFactory dbUtilityFactory)
        {
            _logger = logger;
            _environmentalParameters = envParams.CurrentValue;
            _dbUtilityFactory = dbUtilityFactory;

            userManager = new UserManager(_environmentalParameters, _dbUtilityFactory);
        }


        [Route("GetUserFromTag/{usTag}")]
        [HttpGet]
        public PrimeUser GetFromTag(string usTag)
        {
            string sTag = String.Empty;
            if (usTag == null)
            {
                throw new NullParameterException("Empty Parameter");// TODO Localise
            }
            bool worked = InsecureDataValidator.SecureStringSqlColumn(usTag, out sTag);


            if (worked)
            {
                Task<PrimeUser?> getUser = userManager.GetUserFromTag(sTag);

                if (getUser?.Result != null)
                {
                    PrimeUser foundUser = getUser.Result;
                    return foundUser;
                }
                else throw new NoContentException("No User Found");// TODO Localise
            }

            throw new SecurityException("Invalid");// TODO Localise - also give simple information as we dont want to explain why code does not like text



        }

        [Route("GetUserFromDirection/{id}/{usDirection}")]
        [HttpGet]
        public PrimeUser GetFromTag(Guid id, string usDirection)
        {
            // guid safe as stongly typed
            string sDirection = String.Empty;
            if (usDirection == null)
            {
                throw new NullParameterException("Empty Parameter");// TODO Localise
            }
            bool worked = InsecureDataValidator.SecureStringSqlColumn(usDirection, out sDirection);


            if (worked)
            {
                Task<PrimeUser?> getUser = userManager.GetNextUserFromDirection(id, sDirection);

                if (getUser?.Result != null)
                {
                    PrimeUser foundUser = getUser.Result;
                    return foundUser;
                }
                else throw new NoContentException("No User Found");// TODO Localise
            }

            throw new SecurityException("Invalid");// TODO Localise - also give simple information as we dont want to explain why code does not like text



        }

        [Route("GetUserFromGuid/{guuid}")]
        [HttpGet]
        public PrimeUser GetFromGuid(Guid guuid)
        {
            Task<PrimeUser> getUser = userManager.GetUserFromGuid(guuid);

            if (getUser?.Result != null)
            {
                PrimeUser foundUser = getUser.Result;
                return foundUser;
            }
            else throw new NoContentException("No User Found");// TODO Localise


        }

        [Route("GetUserFromCode/{usCode}")]
        [AllowAnonymous]
        [HttpGet]
        public PrimeUser GetFromCode(string usCode)
        {
            string sCode = String.Empty;
            if(usCode == null)
            {
                throw new NullParameterException("Empty Parameter");// TODO Localise
            }
            bool worked = InsecureDataValidator.SecureStringSqlColumn(usCode, out sCode);

            if (worked)
            {
                Task<PrimeUser?> getUser = userManager.GetUserFromCode(sCode);

                if (getUser?.Result != null)
                {
                    PrimeUser foundUser = getUser.Result;
                    return foundUser;
                }
                else throw new NoContentException("No User Found");// TODO Localise
            }

            throw new SecurityException("Invalid");// TODO Localise - also give simple information as we dont want to explain why code does not like text



        }



        [Route("GetAllActiveUsers")]
        [HttpGet]
        public PrimeUserCollection GetAllActiveUsers()
        {
            Task<PrimeUserCollection> getUser = userManager.GetAllActiveUsers();

            if (getUser?.Result != null)
            {
                PrimeUserCollection foundUsers = getUser.Result;
                return foundUsers;
            }
            else return new PrimeUserCollection();


        }
    }
}
