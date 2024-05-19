using Azure.Security.KeyVault.Secrets;

namespace UserDomainServer.Security
{
    public static class KeyVaultUtility
    {
        /// <summary>
        /// Returns the azure secret. If the secret doesn't exist return string.Empty
        /// </summary>
        public static async Task<string> GetSecret(SecretClient client, string environmentPrefix, string secretName, bool mandatory = true)
        {
            try
            {
                Azure.Response<KeyVaultSecret> keyVaultSecret = await client.GetSecretAsync(environmentPrefix + secretName);

                return keyVaultSecret.Value.Value;
            }
            catch (Exception e)
            {
                if (mandatory)
                    throw new Exception(string.Format("Unable to retrieve '{0}' secret.", environmentPrefix + secretName), e);
                else
                    return string.Empty;
            }
        }


    }
}
