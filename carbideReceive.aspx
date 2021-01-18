<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carbideReceive.aspx.cs" Inherits="CarbideWebApp.recieveOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Carbide Master</title>
    <link href="~/Styles/Site.css" rel="stylesheet" />
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
    </style>

    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js"></script>
        
    <script>
        function jScript() {
            $('#TextBox1').focus();
            var $inp = $('.cls');
            $inp.bind('keydown', function (e) {
                //var key = (e.keyCode ? e.keyCode : e.charCode);
                var key = e.which;
                if (key == 38) {
                    e.preventDefault();
                    var nxtIdx = $inp.index(this) - 1;
                    $(".cls:eq(" + nxtIdx + ")").focus();
                    $(".cls:eq(" + nxtIdx + ")").select();

                    document.getElementById("trackArrowKeyDown").value = "Up";
                }
                if (key == 40) {
                    e.preventDefault();
                    var nxtIdx = $inp.index(this) + 1;
                    $(".cls:eq(" + nxtIdx + ")").focus();
                    $(".cls:eq(" + nxtIdx + ")").select();
                    document.getElementById("trackArrowKeyDown").value = "Down";
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
    <form id="form1" runat="server" style="margin-bottom:100px;">
        <br />
    <h2 style="text-align: center; color: rosybrown;">Receive Order</h2>
    <br />
        <%--   <script type="text/javascript">
        function alertMe(i) {             
            var txt = document.getElementById("GridView1").rows[0].cells[5].innerHTML;
            alert('hello' + txt);
        };
    </script>--%>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <script type="text/javascript" language="javascript">
                    Sys.Application.add_load(jScript);
            </script>

    <div>
        <table style="margin: 0px auto;">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Order" Width="100px"></asp:Label>&nbsp;&nbsp;</td>
                <%--<td><asp:Label ID="Label2" runat="server" Text="Challan No."></asp:Label>&nbsp;&nbsp;</td> --%>
                <td><asp:Label ID="Label3" runat="server" Text="Delivery Date"></asp:Label>&nbsp;&nbsp;</td>                
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="orderNumDropDownList" runat="server" class="form-control" 
                        OnSelectedIndexChanged="orderNumDropDownList_SelectedIndexChanged" 
                        AutoPostBack="true" Width="150px" Style="text-align-last:center" required>
                        <asp:ListItem Text="--select--" Value=""></asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;</td> 
                <%--<td><asp:TextBox ID="TextBox2" class="form-control" runat="server" Width="100px" Style="text-align: center" ReadOnly="true"></asp:TextBox>&nbsp;&nbsp;</td> --%>
                <td><asp:TextBox ID="deliveryDateTxtBox" class="form-control" runat="server" 
                        Width="150px" Style="text-align: center; margin-right:10px;" required></asp:TextBox>&nbsp;&nbsp;</td> 
                <td><asp:Button ID="saveBtn" style="margin-top:-25px" runat="server" 
                        class="btn btn-primary" Text="Save" Width="100px" OnClick="saveBtn_Click" />&nbsp;&nbsp;
                    <asp:Button ID="exitBtn" runat="server" style="margin-top:-25px" 
                        class="btn btn-primary" Text="Exit" Width="100px" />&nbsp;&nbsp;
                </td> 
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" runat="server" Text="Order Date" ></asp:Label></td>
                <td><asp:Label ID="Label5" runat="server" Text="Inq./Ref."></asp:Label></td>
                <td><asp:Label ID="Label6" runat="server" Text="Vendor"></asp:Label></td>
                <td><asp:Label ID="Label7" runat="server" Text="Vendor Name"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="orderDateTxtBox" class="form-control" runat="server" 
                        Width="100px" Style="text-align: center; width:95%; margin-right:10px;" required></asp:TextBox></td>
                <td><asp:TextBox ID="enqRefTxtBox" class="form-control" runat="server" 
                        Width="100px" Style="text-align: center;margin-right:10px;" required></asp:TextBox></td>
                <td><asp:TextBox ID="vendorTxtBox" class="form-control" runat="server" 
                        Width="100px" Style="text-align: center;margin-right:10px;" required></asp:TextBox></td>
                <td><asp:TextBox ID="vendorNameTxtBox" class="form-control" runat="server" 
                        Width="250px" Style="text-align: center" required></asp:TextBox></td>
            </tr>
           
        </table>
        <br />
        <asp:GridView ID="GridView1" runat="server"  Width="85%" AutoGenerateColumns="false" HeaderStyle-CssClass="GridHeader"  EnableViewState="true" HorizontalAlign="Center" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns> 
                    <asp:TemplateField HeaderText="UID" HeaderStyle-Width="150px">

                        <ItemTemplate>

                            <asp:Label ID="uidLbl" runat="server" Text='<%# Eval("NumOrd") %>'></asp:Label>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Element" HeaderStyle-Width="150px">

                        <ItemTemplate>

                            <asp:Label ID="elementLbl" runat="server" Text='<%# Eval("CodPie") %>'></asp:Label>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Step" HeaderStyle-Width="150px">

                        <ItemTemplate>

                            <asp:Label ID="stepLbl" runat="server" Text='<%# Eval("NumFas") %>'></asp:Label>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Article" HeaderStyle-Width="150px">

                        <ItemTemplate>
                            <asp:Label ID="articleLbl" runat="server" Text='<%# Eval("ArtOrd") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="150px">

                        <ItemTemplate>
                            
                            <asp:Label ID="deliverydateLbl" runat="server" Text='<%# Bind("PlaPie","{0:dd/MMM/yyyy}") %>'></asp:Label>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order Quantity" HeaderStyle-Width="150px">

                        <ItemTemplate>
                            <asp:Label ID="orderQuantityLbl" runat="server" Text='<%# Eval("PiePed") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity Received" HeaderStyle-Width="150px">

                        <ItemTemplate>

                            <asp:TextBox class="cls" Width="100%" ID="quantityReceivedTxtBox" runat="server" Text='<%# Eval("PieRec") %>' AutoPostBack="true" required OnTextChanged="quantityReceivedTxtBox_TextChanged"></asp:TextBox>
                           
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity Pending" HeaderStyle-Width="150px">

                        <ItemTemplate>
                            <asp:Label ID="quantitypendingLbl" runat="server" Text='<%# Eval("Quantity Pending") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    
            
            
            
            
            
            
            
            
            
            
            
            
            
                          
                <%--<asp:BoundField DataField="NumOrd" ItemStyle-Width="60px" HeaderText="UID" 
                    ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="CodPie" ItemStyle-Width="60px" HeaderText="Element" 
                    HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  >
<HeaderStyle Width="60px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="NumFas" ItemStyle-Width="60px" HeaderText="Step" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Article" HeaderText="Article" 
                    HeaderStyle-Width="140px" ItemStyle-HorizontalAlign="Center" >
<HeaderStyle Width="140px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="PlaPie" HeaderText="Delivery Date" 
                    DataFormatString="{0: dd/MM/yyyy}" ReadOnly="true" HeaderStyle-Width="120px"  
                    ItemStyle-HorizontalAlign="Center" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="PiePed" HeaderText="Quantity Order" 
                    HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="AuxCtd" HeaderText="Quantity Received" 
                    HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
               
                <asp:TemplateField ItemStyle-Width="80px" HeaderText="Quantity Pending" ItemStyle-HorizontalAlign="Center"  >
                    <ItemTemplate >
                        <asp:TextBox id="t2" runat="server"  Width="100%" Height="20px"   Text='<%# Eval("Quantity Pending") %>'></asp:TextBox>
                     </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                </asp:TemplateField>
                --%>
            </Columns>

<HeaderStyle CssClass="GridHeader" BackColor="Black" ForeColor="White"></HeaderStyle>
        </asp:GridView>
    </div>
                <asp:HiddenField ID="trackArrowKeyDown" runat="server" ClientIDMode="Static"/>

    </ContentTemplate>
        </asp:UpdatePanel>
    </form>


     <script src="Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
</body>
</html>
