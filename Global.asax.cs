using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PROJETO_CADASTRO_FINALERA_2
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Configuração de rota para redirecionar a página inicial para About.aspx
            RouteTable.Routes.MapPageRoute("DefaultRoute", "", "~/About.aspx");
        }
    }
}