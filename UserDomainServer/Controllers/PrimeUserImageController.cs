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
using UserDomain.Properties;
using UserDomainServer.Security;
using UserDomainServer.Security.Exceptions;

namespace UserDomainServer.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class PrimeUserImageController : ControllerBase
    {
        private readonly ILogger<PrimeGetUserController> _logger;
        private readonly IEnvironmentalParameters _environmentalParameters;
        private readonly IDbUtilityFactory _dbUtilityFactory;

        private IUserManager userManager = new UserManager();

        public PrimeUserImageController(ILogger<PrimeGetUserController> logger, IOptionsMonitor<EnvironmentalParameters> envParams, IDbUtilityFactory dbUtilityFactory)
        {
            _logger = logger;
            _environmentalParameters = envParams.CurrentValue;
            _dbUtilityFactory = dbUtilityFactory;

            userManager = new UserManager(_environmentalParameters, _dbUtilityFactory);
        }


        [Route("GetUserImageFromGuid/{guuid}/{target}")]
        [HttpGet]
        public UserImage GetUserImageUrlFromGuid(Guid guuid, IMAGE_TYPE target)
        {
            Task<List<UserImage>> allImages = userManager.GetUserImages(guuid);

            if (allImages?.Result != null)
            {
                UserImage? foundImage = allImages.Result.FirstOrDefault(x => x.ImageType == target);
                if(foundImage != null)
                {
                    return foundImage;
                }

                
            }
            else throw new NoContentException("No Matching User Image Found");// TODO Localise

            // TODO return a default image
            return new UserImage();
        }
    }
}