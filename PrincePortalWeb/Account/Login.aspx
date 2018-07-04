<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PrincePortalWeb.Account.Login" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="../Content/CSS/Login.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-theme.css" rel="stylesheet" />


</head>

<body class="bg">
    <form id="form1" runat="server">
        
        <div class="container col-md-4 col-md-offset-4 ">

            <div class="modal-dialog loginform-container">
                <div class="modal-content">

                    <div class="logo" id="logo">

                        <img src="../Content/Images/logo.PNG" class="justify-content-center" />

                    </div>

                    <div class="logo">
                        <h2 class="text-center">Please Login</h2>
                    </div>
                    

                    <div class="modal-body">
                        <div class="form-group">
                            <input id="textUsername" type="text" class="form-control input-lg" placeholder="Username" required="required" runat="server" autocomplete="off" />
                        </div>

                        <div class="form-group">
                            <input id="textPassword" type="password" class="form-control input-lg" placeholder="Password" required="required" runat="server" autocomplete="off" />
                        </div>                     

                        <div class="form-group">

                            <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="LogIn" Class="btn btn-block btn-lg btn-primary" />
                        </div>

                        <div id="dvMessage" runat="server" visible="false" class="justify-content-center alert alert-danger">
                            <strong>Error!</strong>
                            <asp:Label ID="lblMessage" runat="server" />
                        </div>
                    </div>
                </div>

            </div>


        </div>



    </form>
</body>
</html>
