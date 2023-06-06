using VTPLibrary;
using VTPLibrary.Models.Request;
using VTPLibrary.Models.Response;

var client = new VTPClient();
var token = CancellationToken.None;
var phone = "0357090609";

var res1 = await client.SyncKey(phone, token);

var validate = new ValidateAccountRequestModel(phone);
var validateRes = await client.GetByCmd(ValidateAccountRequestModel.Cmd, validate, token);

var login = new AuthLoginRequestModel(phone, "552001");
var loginRes = await client.GetByCmd(AuthLoginRequestModel.Cmd, login, token);
var loginResInfo = loginRes.GetData<AuthLoginResponseModel>(client.Key);

AuthLoginOTPResponseModel? loginInfo = null;
if (loginResInfo.RequestId != null)
{
    var loginOtp = new AuthLoginOTPRequestModel(phone, "552001", Console.ReadLine(), loginResInfo.RequestId);
    var loginOtpRes = await client.GetByCmd(AuthLoginRequestModel.Cmd, loginOtp, token);
    loginInfo = loginOtpRes?.GetData<AuthLoginOTPResponseModel>(client.Key);
}
else loginInfo = loginRes.GetData<AuthLoginOTPResponseModel>(client.Key);

var getAcc = new GetAccountRequestModel(loginInfo.AccessToken, phone);
var getAccRes = await client.GetByCmd(GetAccountRequestModel.Cmd, getAcc, token);
var getAccResInfo = getAccRes.GetData<GetAccountResponseModel>(client.Key);

client._client.DefaultRequestHeaders.Add("Session-Id", getAccResInfo.OtherData.SessionId);
var getBal = new GetBalanceRequestModel(getAccResInfo.Sources.VTPCards[0].CardNumber);
var getBalRes = await client.GetByCmd(GetBalanceRequestModel.Cmd, getBal, token);
var getBalResInfo = getBalRes.GetData<GetBalanceResponseModel>(client.Key);