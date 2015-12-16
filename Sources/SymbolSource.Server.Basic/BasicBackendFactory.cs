// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasicBackendFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The basic backend factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SymbolSource.Server.Basic
{
    using System;
    using System.Collections.Generic;

    using SymbolSource.Gateway.Core;
    using SymbolSource.Processing.Basic.Projects;
    using SymbolSource.Server.Management.Client;

    /// <summary>
    /// The basic backend factory.
    /// </summary>
    public class BasicBackendFactory : IGatewayBackendFactory<BasicBackend>
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IBasicBackendConfiguration configuration;

        /// <summary>
        /// The add info builder.
        /// </summary>
        private readonly IAddInfoBuilder addInfoBuilder;

        /// <summary>
        /// The gateway version extractors.
        /// </summary>
        private readonly IEnumerable<IGatewayVersionExtractor> gatewayVersionExtractors;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicBackendFactory"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="addInfoBuilder">
        /// The add info builder.
        /// </param>
        /// <param name="gatewayVersionExtractors">
        /// The gateway version extractors.
        /// </param>
        public BasicBackendFactory(
            IBasicBackendConfiguration configuration, 
            IAddInfoBuilder addInfoBuilder, 
            IEnumerable<IGatewayVersionExtractor> gatewayVersionExtractors
            )
        {
            this.configuration = configuration;
            this.addInfoBuilder = addInfoBuilder;
            this.gatewayVersionExtractors = gatewayVersionExtractors;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="caller">
        /// The caller.
        /// </param>
        /// <returns>
        /// The <see cref="BasicBackend"/>.
        /// </returns>
        public BasicBackend Create(Caller caller)
        {
            return new BasicBackend(this.configuration, this.addInfoBuilder, this.gatewayVersionExtractors);
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="caller">
        /// The caller.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User Validate(Caller caller)
        {
            return new User
            {
                Name = caller.Name, 
                Company = caller.Company, 
            };
        }

        /// <summary>
        /// The digest generate request.
        /// </summary>
        /// <param name="realm">
        /// The realm.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string DigestGenerateRequest(string realm)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The digest validate response.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="Caller"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Caller DigestValidateResponse(string company, string method, string response)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get user by key.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="Caller"/>.
        /// </returns>
        public Caller GetUserByKey(string company, string type, string value)
        {
            return new Caller
            {
                Company = "Basic", 
                Name = "Basic", 
                KeyType = "Basic", 
                KeyValue = "Basic", 
            };
        }
    }
}