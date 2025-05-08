<%@ Page Title="Brand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="Dotnetframeworkwedapp_ADO.net.Brand" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--Added for styling start--%>
    <style>
        /*.form-container {
            margin-top: 30px;
            background-color: #f9f9f9;
            padding: 25px;
            border-radius: 8px;
            width: 100%;
            max-width: 600px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }*/
        .form-container {
            margin-top: 30px;
            padding: 2px;
            width: 100%;
            max-width: 600px;
        }

        .form-container label {
            font-weight: bold;
        }

        .form-container input[type="text"] {
            width: 100%;
            padding: 8px;
            margin-top: 4px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .form-container .asp-button {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px 16px;
            margin-right: 10px;
            border-radius: 5px;
            cursor: pointer;
        }

        .form-container .asp-button:hover {
            background-color: #0056b3;
        }

        h2 {
            color: #333;
        }
    </style>
    <%--Added for styling end--%>

    <h2>Brand Names.</h2>
    <asp:GridView ID="BrandsGridView" runat="server" 
        BackColor="#CCCCCC" 
        BorderColor="#999999" 
        BorderStyle="Solid" 
        BorderWidth="3px" 
        CellPadding="10" 
        CellSpacing="10" 
        ForeColor="Black"
        Width="70%">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <div class="form-container">
            <asp:Table ID="Crudstatementstbl" runat="server" CellSpacing="10" CellPadding="25">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="BrandIDtxtlbl" runat="server" Text="Enter the Brand ID here: " ></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="BrandIDtxt" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Brandnamelbl" runat="server" Text="Enter the Brand Name here:  "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="BrandNametxt" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="Updatebtn" runat="server" Text="Update" CssClass="asp-button" onclick="Updatebtn_Click"/>
                        <asp:Label ID="UpdateBtnResLbl" runat="server"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Deletebtn" runat="server" Text="Delete" CssClass="asp-button" onclick="Deletebtn_Click"/>
                        <asp:Label ID="Deletereslbl" runat="server"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Insertbtn" runat="server" Text="Insert" CssClass="asp-button" onclick="Insertbtn_Click"/>
                        <asp:Label ID="Insertreslbl" runat="server"></asp:Label>
                    </asp:TableCell>
                    </asp:TableRow>
            </asp:Table>
        </div>
</asp:Content>
