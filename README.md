1. Created default .NET API project and added it to solution
2. Installed node and npm with nvm. Then installed Angular with npm and created default starting application.
3. Created dockerfile through Visual Studio for .NET API
4. Downloaded dockerfile for app1 for default angular building and hosting
5. Looked into kuberneters on docker desktop, enabled the functionality
6. Read more about docker compose, kubernetes and helm
7. Added docker-compose.yml file while following tutorial on docker website
8. Tried running it with `docker compose up`. Angular app works! .NET api works!
9. Following information mentioned at links and guide to call api's from angular to test communication https://angular.io/guide/http
10. Finished up on trying to get the angular app communicating with the .NET API by using a reverse proxy to route traffic. Learning some ideas through https://github.com/docker/awesome-compose/tree/master/nginx-aspnet-mysql
11. Read more info about the mariadb container image to figure to get more understanding how to start it up and also provide fast restoring. https://hub.docker.com/_/mariadb Added a dockerfile and startup sql file. Passwordless root user due to just local dev purposes.
12. Start adding EF Core by adding package to https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql (Found through Micosoft website). Also added the EF Core Design package. Started writing the model, context and ef configuration. Following https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio-code