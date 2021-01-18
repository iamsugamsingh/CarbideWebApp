<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carbideEnquiry.aspx.cs" Inherits="CarbideWebApp.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Carbide Master</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/images/ANU%20LOGO.jpg" rel="icon" type="image/png" />

    <style>
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
        .cls
        {
            border:none;
            }
    </style>
    
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js"></script>
        
    <script>
        function jScript() {
            $('#TextBox1').focus();
            var $inp = $('.cls');
            $inp.bind('keydown', function (e) {
                //var key = (e.keyCode ? e.keyCode : e.charCode);
                var key = e.which;
                if (key == 13) {
                    e.preventDefault();
                    var nxtIdx = $inp.index(this) + 1;
                    $(".cls:eq(" + nxtIdx + ")").focus();
                    if (nxtIdx % 14 == 0) {
                        $(".cls:eq(" + nxtIdx + ")").focus();
                        $(".cls:eq(" + nxtIdx + ")").click();
                        $(".cls:eq(" + nxtIdx + ")").select();
                    }
                }
                if (key == 38) {
                    e.preventDefault();
                    var nxtIdx = $inp.index(this) - 14;
                    $(".cls:eq(" + nxtIdx + ")").focus();
                    $(".cls:eq(" + nxtIdx + ")").select();
                }
                if (key == 40) {
                    e.preventDefault();
                    var nxtIdx = $inp.index(this) + 14;
                    $(".cls:eq(" + nxtIdx + ")").focus();
                    $(".cls:eq(" + nxtIdx + ")").select();
                }
                if (key == 37) {
                    e.preventDefault();
                    var nxtIdx = $inp.index(this) - 1;
                    $(".cls:eq(" + nxtIdx + ")").focus();
                    $(".cls:eq(" + nxtIdx + ")").select();
                }
                if (key == 39) {
                    e.preventDefault();
                    var nxtIdx = $inp.index(this) + 1;
                    $(".cls:eq(" + nxtIdx + ")").focus();
                    $(".cls:eq(" + nxtIdx + ")").select();
                }
            });
        }
    </script>
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

    <div class="container-fluid" style="margin:auto;">
        
        <div class="row">
            <div class="col-lg-4">
                <h4 style="padding-top:15px;">Location:- "Aws-<%= location %>"</h4>
            </div>
            <div class="col-lg-4">
                <h2 style="text-align:center;">Carbide Enquiry</h2>
            </div>
            <%--<div class="col-lg-4">
                <h4 style="padding-top:15px; float:right;">
                    <asp:Label ID="totalRowsLabel" runat="server" Text="Total Rows:- "></asp:Label>
                    <asp:Label ID="totalRowsCount" runat="server"></asp:Label>
                </h4>
            </div>--%>
        </div>



        <form id="form1" runat="server" style="width:100%; margin-top:25px;">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <script type="text/javascript" language="javascript">
                    Sys.Application.add_load(jScript);
            </script>
            

        <%--<asp:Button ID="deleteBtn" runat="server" class="btn btn-primary" Text="Button" onclick="Delete_Click"/>--%>
            <asp:GridView ID="GridView1" runat="server" ShowFooter="true" 
                AutoGenerateColumns="false" Width="100%" Font-Size="Small" OnRowCommand="GridView1_RowCommand" HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle">

                <Columns>
                    <asp:TemplateField HeaderText = "Remove Rows" ItemStyle-Width="100" >  
                        <ItemTemplate>  
                            <asp:Button ID="removeBtn" class="btn btn-xs" runat="server" style="background:red;color:White; width:100%;" Text="Remove" onclick="removeBtn_Click" AccessKey="r" />
                        </ItemTemplate>  
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText = "Row Number" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="UID">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox1" required runat="server" Width="100px" OnTextChanged="OnUidChanged" AutoPostBack="true" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" AccessKey="u"></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Customer ID">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox2" required runat="server" Width="150px"></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox3" runat="server" Width="200px" required></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Element">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox4" runat="server" Width="70px" required OnTextChanged="OnElementChanged" AutoPostBack="true" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" AccessKey="b"></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Multiplier">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox5" runat="server" Width="70px" required OnTextChanged="Multiplier_change" AutoPostBack="true"></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order Quantity">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox6" runat="server" Width="85px" required OnTextChanged="OrderQuantity_change" AutoPostBack="true"></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox7" runat="server" Width="55px" required></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity To Order">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox8" runat="server" Width="70px" AccessKey="q" required></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Grade">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox9" runat="server" Width="65px" required></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Model">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox10" runat="server" Width="50px" required></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Outer Diameter">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox11" runat="server" Width="70px" required></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Length">

                        <ItemTemplate>

                            <asp:TextBox class="cls" ID="TextBox12" runat="server" Width="50px" required></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Internal Diameter">

                        <ItemTemplate>

                             <asp:TextBox class="cls" ID="TextBox13" runat="server" Width="70px" required></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Article Number">

                        <ItemTemplate>

                             <asp:TextBox class="cls" ID="TextBox14" runat="server" Width="100px" AccessKey="a" required></asp:TextBox>

                        </ItemTemplate>

                        <FooterStyle HorizontalAlign="Right" />

                        <FooterTemplate>

                         <asp:Button ID="ButtonAdd" class="cls btn btn-xs" runat="server" style="background:green;color:White; width:100%; border:none;" Text="Add New Row" onClick="ButtonAdd_Click" BorderStyle="Outset" AccessKey="n" />

                        </FooterTemplate>

                    </asp:TemplateField>

                </Columns>
                <HeaderStyle BackColor="Black" ForeColor="White" HorizontalAlign="Center" 
                    VerticalAlign="Middle" />
            </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
            <center>
                <asp:Button ID="submitButton" runat="server" Text="Submit" 
                    class="btn btn-success" Style="width:200px; margin-top:50px; font-size:larger" 
                    onclick="submitButton_Click"/>
            </center>
    </form>
    </div>
    

    <script src="Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
</body>
</html>
