// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer
{
    /// <summary>
    /// TO-DO These infos can be read from a specific db
    /// </summary>
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] {
            new ApiResource("resource_catalog") {  Scopes={ "catalog_fullpermission" } }, // each ApiResource van have multiple Scopes
            new ApiResource("resource_photo_stock") {  Scopes={ "photo_stock_fullpermission" } }, // a scope can be shared different ApiResources
            new ApiResource("resource_basket") {  Scopes={ "basket_fullpermission" } },
            new ApiResource("resource_discount") {  Scopes={ "discount_fullpermission" } },
            new ApiResource("resource_order") {  Scopes={ "order_fullpermission" } },
            new ApiResource("resource_payment") {  Scopes={ "payment_fullpermission" } },
            new ApiResource("resource_gateway") {  Scopes={ "gateway_fullpermission" } },

            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)  // identity nin kendine istek yapabilmesi için
        };

        /// <summary>
        /// https://docs.identityserver.io/en/latest/quickstarts/1_client_credentials.html
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources => //An identity resource is a named group of claims that can be requested using the scope parameter.
                new IdentityResource[] // This resource is consumed  by the client one that has type of GrantTypes.ResourceOwnerPassword
                {
                    new IdentityResources.Email(),
                    new IdentityResources.OpenId(), //"sub"  this is "id" in the JWT payload, and mandatory
                    new IdentityResources.Profile(),
                    new IdentityResource()
                        {
                            Name="roles", // custom Resource named "roles"
                            DisplayName="Roles",
                            Description="Kullanıcı Rolleri",
                            UserClaims= new []{"role"}
                        }  //custom
                };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Full permission for CATALOG API"), /// Api scope can have UserClaims 
                new ApiScope("photo_stock_fullpermission","Full permission for PHOTO_STOCK API"),
                new ApiScope("basket_fullpermission","Full permission for BASKET API"),
                new ApiScope("discount_fullpermission","Full permission for DISCOUNT API"),
                new ApiScope("order_fullpermission","Full permission for ORDER API"),
                new ApiScope("payment_fullpermission","Full permission for PAYMENT API"),
                new ApiScope("gateway_fullpermission","Full permission for Gateway"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName) // MVC içerisinden signup yapabilmek için de bunu vermemzi gerek
            };
        public static IEnumerable<Client> Clients =>
            new Client[] // Client represents app that request to IDS.Not a user. machine to machine.
            {
                new Client
                {
                    ClientName="ASP.Net Core MVC",
                    ClientSecrets= { new Secret("secret".Sha256()) },
                    ClientId="WebMvcClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials, // This grand types do not support to refresh token
                    AllowedScopes=
                    { "catalog_fullpermission",
                        "photo_stock_fullpermission",
                        "gateway_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName
                    }// alloweed scopes.
                },
                new Client
                {
                    ClientName="ASP.Net Core MVC",
                    ClientSecrets= { new Secret("secret".Sha256()) },
                    ClientId="WebMvcClientForUser",
                    AllowOfflineAccess = true,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes= {
                                     "basket_fullpermission",
                                     "order_fullpermission",
                                     "gateway_fullpermission",
                                     IdentityServerConstants.StandardScopes.Email, // resource info which return to client (returned token contains infos such as email,openId,profile and roles)
                                     IdentityServerConstants.StandardScopes.OpenId,//  Once the IdentityResource is defined, you can give access to it to a client via the AllowedScopes option
                                     IdentityServerConstants.StandardScopes.Profile,
                                     IdentityServerConstants.StandardScopes.OfflineAccess,
                                      "roles",
                                      IdentityServerConstants.LocalApi.ScopeName // Identitynin kendisine istek yapabilmek için lazım. 
                    }, //refresh token
                    AccessTokenLifetime = 60*60, // 1 hour
                    RefreshTokenExpiration = TokenExpiration.Absolute,// Kesin bir tarih mi yoksa sliding mi
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds, //refresh token invalids at the end of the 61st day
                    RefreshTokenUsage = TokenUsage.ReUse// onetime or reusable
                },
                new Client
                {
                   ClientName="Token Exchange Client",
                    ClientId="TokenExhangeClient",
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowedGrantTypes= new []{ "urn:ietf:params:oauth:grant-type:token-exchange" },
                    AllowedScopes={ "discount_fullpermission", "payment_fullpermission", IdentityServerConstants.StandardScopes.OpenId }
                },
            };
    }
}

//SAMPLE JWT PAYLOAD 
/*
 {
  "nbf": 1639450838,
  "exp": 1639454438,
  "iss": "https://localhost:5001",
  "aud": [
    "resource_catalog",
    "photo_stock_catalog",
    "https://localhost:5001/resources"
  ],
  "client_id": "WebMvcClient",
  "jti": "566A1764F4E2212BBBD4DCDA5571E99E",
  "iat": 1639450837,
  "scope": [
    "catalog_fullpermission",
    "IdentityServerApi",
    "photo_stock_fullpermission"
  ]
}
 */

/*
 {
  "nbf": 1641827379,
  "exp": 1641830979,
  "iss": "http://localhost:5001",
  "aud": "http://localhost:5001/resources",
  "client_id": "WebMvcClientForUser",
  "sub": "3f8354f7-ee3d-455d-8ac1-2301ef9a5fc7",
  "auth_time": 1641827378,
  "idp": "local",
  "jti": "5F3CDB238ADCA6F2877061AFA5E55F32",
  "iat": 1641827379,
  "scope": [
    "email",
    "IdentityServerApi",
    "openid",
    "profile",
    "roles",
    "offline_access"
  ],
  "amr": [
    "pwd"
  ]
}
 */