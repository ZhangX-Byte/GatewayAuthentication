# .NET Core + Ocelot + IdentityServer4 + Consul 基础架构实现
#### 先决条件
* 关于 Ocelot
  * 针对使用 .NET 开发微服务架构或者面向服务架构提供一个统一访问系统的组件。 [参考](http://threemammals.com/ocelot)
  * 本文将使用 Ocelot 构建统一入口的 Gateway。
* 关于 IdentityServer4
  * IdentityServer4 是一个 OpenID Connect 和 OAuth 2.0 框架用于 [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2) 。IdentityServer4 在你的应用程序中集成了基于令牌认证、单点登录、API访问控制所需的所有协议和扩展点。[参考](http://docs.identityserver.io/en/latest/)
  * 本文将使用 IdentityServer4 搭建独立认证服务器。
* 关于 Consul
  * Consul 是一个服务网格解决方案，通过服务发现、配置、功能分割提供一个全功能的控制层。这些功能可以单独使用，也可以同时使用以形成一个完整的网格服务。[参考](https://www.consul.io/intro/index.html)
  * 本文将使用 Consul 注册多个服务。
* 关于 .Net Core
  * 将使用 WebApi 构建多个服务

#### 构建 IdentityServer 服务
1. 添加 ASP.Net Core Web 项目
    <img src="https://raw.githubusercontent.com/SoMeDay-Zhang/GatewayAuthentication/master/Documents/Images/IdentityServerCreate1.png" height="400px" />
    
2. 添加空项目
    <img src="https://raw.githubusercontent.com/SoMeDay-Zhang/GatewayAuthentication/master/Documents/Images/IdentityServerCreate2.png" height="400px" />

3. 在程序包管理控制台中输入
    ```
    Install-Package IdentityServer4.AspNetIdentity
    ```
