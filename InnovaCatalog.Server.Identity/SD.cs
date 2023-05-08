using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace InnovaCatalog.Server.Identity
{
    public class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> { 
                new ApiScope("innovacatalog", "Innova Server"),
                new ApiScope(name: "read", "Read your data "),
                new ApiScope(name: "write", "Read your data "),
                new ApiScope(name: "delete", "Read your data ")

            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    ClientSecrets={new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes={"read","write","profile" }
                },
                new Client
                {
                    ClientId="innova",
                    ClientSecrets={new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris={ "https://localhost:44313/signin-oidc" },
                    PostLogoutRedirectUris={"https://localhost:44313/signout-callback-oidc"},
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "innova"

                    }
                },

            };

    }
}
