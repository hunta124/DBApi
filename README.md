# DBApi
You can run this API service after download with running in IISExpress.
When it's start run it is open swagger page with list of methods and posibility to run each of them.
Every methods contain params to run.
By default it's run without checks of api key.
In case to check running with Api Key you have to open file Controller\DBServiceController.cs and remove comments
in row 13 where is [ApiKey] and in StartUp.cs remove comments in row 86 app.UseMiddleware<ApiKeyMiddleware>().
To check Api with Api key have to use Postman where is you can edit header params(add ApiKey=dun123AnDbre234)
After download project in appsettings.json have to check and change Connection string to your local.
