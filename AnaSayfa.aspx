<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="IsTakipProgramı.AnaSayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sortable row-fluid">
        <a data-rel="tooltip" title="" class="well span3 top-block" href="#">
            <span class="icon32 icon-red icon-user"></span>
            <div>Toplam Üye</div>
            <asp:Label ID="lblUyeSayi" runat="server" Text=""></asp:Label>
            <span class="notification"></span>
        </a>

        <a data-rel="tooltip" title="" class="well span3 top-block" href="#">
            <span class="icon32 icon-color icon-star-on"></span>
            <div>Toplam Çağrı Sayısı</div>
            <asp:Label ID="lblCagriSayi" runat="server" Text=""></asp:Label>
            <span class="notification green"></span>
        </a>

        <a data-rel="tooltip" title="" class="well span3 top-block" href="#">
            <span class="icon32 icon-color icon-cart"></span>
            <div>Departman Sayısı</div>
            <asp:Label ID="lblDepartmanSayi" runat="server" Text=""></asp:Label>
            <span class="notification yellow"></span>
        </a>
    </div>
</asp:Content>