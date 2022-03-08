To run daprized applications run following commands in the Terminal:

Initialize Dapr
```shell
dapr init
```

Run OrderService
```shell
dapr run --app-id OrderService --app-port 5280 --dapr-http-port 3500 -- dotnet run --project src/OrderService 
```

Run ContributionService
```shell
dapr run --app-id ContributionService --app-port 5127 --dapr-http-port 3501 -- dotnet run --project src/ContributionService 
```

Run PaymentGatewayService
```shell
dapr run --app-id PaymentGatewayService --app-port 5094 --dapr-http-port 3502 -- dotnet run --project src/PaymentGatewayService 
```

To test the services open the postman/OrderService.http file in Visual Studio Code.