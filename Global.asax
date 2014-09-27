<%@ Application Language="C#" %>
<%@ Import Namespace="HickoryPTASite" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        var membershipContextConfiguration = new PTAData.Migrations.MembershipContextMigrations.Configuration();
        var migrator = new System.Data.Entity.Migrations.DbMigrator(membershipContextConfiguration);
        migrator.Update();

        var applicationUserConfiguration = new PTAData.Migrations.ApplicationUserContextMigrations.Configuration();
        migrator = new System.Data.Entity.Migrations.DbMigrator(applicationUserConfiguration);
        migrator.Update();
    }

</script>
