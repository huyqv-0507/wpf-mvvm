using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResponseModels = WpfAppLogin.Models.ResponseModels;
using RequestModels = WpfAppLogin.Models.RequestModels;
using System.Net.Http;

namespace WpfAppLogin.Services
{
    public class AuthenticationService
    {
        private string _tokenUrl = "/token";
        public async Task<ResponseModels.TokenModel> GetToken(RequestModels.TokenModel tokenModel)
        {
            var requestParams = new Dictionary<string, string>();
            requestParams.Add("type", tokenModel.Type.ToString());
            requestParams.Add("username", tokenModel.UserName);
            requestParams.Add("password", tokenModel.Password);
            requestParams.Add("grant_type", tokenModel.GrantType);

            ResponseModels.TokenModel tokenResponseModel =
                await ServiceBase<ResponseModels.TokenModel>.DoPost(
                    _tokenUrl,
                    requestParams,
                    APIConst.ContentType.APPLICATION_FORM_URLENCODED
                    );

            return tokenResponseModel;
        }
    }
}
