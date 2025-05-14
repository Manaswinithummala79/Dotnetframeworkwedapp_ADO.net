<%@ Page Title="Brand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="Dotnetframeworkwedapp_ADO.net.Brand" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <div>   

        <asp:GridView ID="GridView1" runat="server" DataSourceID="BikeStoresEntities">
        </asp:GridView>

        <asp:EntityDataSource ID="BikeStoresEntities" runat="server">
        </asp:EntityDataSource>

    </div>
</asp:Content>
