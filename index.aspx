<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CarbideWebApp.home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carbide Master</title>
    <link href="~/Styles/Site.css" rel="stylesheet" />
    <link href="~/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/images/ANU%20LOGO.jpg" rel="icon" type="image/png" />
    <style type="text/css">
        
        .card
        {
            height:250px;
            box-shadow:10px 10px 10px gray;           
            border:1px solid; 
        }
        
        .orderbackground
        {
            background:#3390ff;
        }
        
        .navbar
        {
            background:#3390ff;
            border-radius:0px;
            box-shadow:2px 2px 5px black;
        }
            
        .navbar-brand, .navbar-brand:hover
        {
            color:White;
        }
        
        .nav > li >a, .nav > li >a:hover
        {
            color:White;
            background:#3390ff;
        }


    </style>
</head>
<body>
    
    <nav class="navbar navbar">
        <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="#" style="font-size:20px; font-weight:bold; margin-left:90px;">Carbide Master</a>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">            
            <ul class="nav navbar-nav navbar-right" style="margin-right:90px; font-size:16px; font-weight:bold;">
                <li><a href="index.aspx">Home</a></li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Enquiry <span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="carbideEnquiry.aspx?location=1">AWS-1</a></li>
                        <li><a href="carbideEnquiry.aspx?location=2">AWS-2</a></li>
                    </ul>
                </li>
                <li><a href="carbideOrder.aspx">Order</a></li>
                <li><a href="carbideReceive.aspx">Receive</a></li>
            </ul>
        </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
    </nav>
    <form id="form1" runat="server" style="margin-top:150px;">
    <div class="container">
        <div class="row">
          <div class="col-sm-6 col-md-4">

          <asp:LinkButton ID="orderBtn" runat="server" style="display:block; text-decoration:none; text-align:center;" onclick="orderBtn_Click">
            <div class="thumbnail card orderbackground">
              <div class="caption">                  
                   <h1 style="line-height:180px;">Order</h1>                  
              </div>
            </div>
            </asp:LinkButton>
          </div>

          <div class="col-sm-6 col-md-4">

          <asp:LinkButton ID="inquiryBtn" runat="server" data-toggle="modal" data-target=".bs-example-modal-lg" style="display:block; text-decoration:none; text-align:center;">
            <div class="thumbnail card enquirybackground" style="height:250px; box-shadow:10px 10px 10px gray; background:tomato;border:1px solid;">
              <div class="caption">                  
                    <h1 style="line-height:180px;">Enquiry</h1>                  
              </div>
            </div>
            </asp:LinkButton>
          </div>

          <div class="col-sm-6 col-md-4">
          <asp:LinkButton ID="recieveBtn" runat="server" style="display:block; text-decoration:none; text-align:center;" onclick="recieveBtn_Click" >
            <div class="thumbnail " style="height:250px; box-shadow:10px 10px 10px gray; background:#f0ad4e;border:1px solid;">
              <div class="caption">                  
                    <h1 style="line-height:180px;">Receive</h1>                    
              </div>
            </div>
            </asp:LinkButton>
          </div>
        </div>
    </div>

    <!--Modal Content-->

    <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
      <div class="modal-dialog" role="document" style="margin-top:175px;">
        <div class="modal-content" style="height:250px; background:transparent;">
          <div class="row">
          <div class="col-sm-6">
          <asp:LinkButton ID="aws1" runat="server" style="display:block; text-decoration:none; text-align:center;"  onclick="aws1_Click">
            <div class="thumbnail " style="height:250px; background:#800080; border:1px solid;">
              <div class="caption">                  
                   <h1 style="line-height:180px; color:White;">AWS-1</h1>                  
              </div>
            </div>
            </asp:LinkButton>
          </div>

          <div class="col-sm-6">
          <asp:LinkButton ID="aws2" runat="server" style="display:block; text-decoration:none; text-align:center;"  onclick="aws2_Click">
            <div class="thumbnail " style="height:250px; background:#FFA500;border:1px solid;">
              <div class="caption">                  
                    <h1 style="line-height:180px; color:White;">AWS-2</h1>                  
              </div>
            </div>
            </asp:LinkButton>
          </div>
          </div>
        </div>
      </div>
    </div>
    </form>



    
    <script src="Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
</body>
</html>
