<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Departmanlar.aspx.cs" Inherits="IsTakipProgramı.Departmanlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblKullaniciYetki" runat="server" Text="">
        <div class="alert alert-error">        
            <button type="button" class="close" data-dismiss="alert">×</button>
            <strong>Bu işlem için yetkiniz bulunmamaktadır!</strong>            
        </div>
    </asp:Label>
    <asp:Panel ID="pnlKullaniciYetki" runat="server">
        <asp:Panel ID="pnlDepartmanEkle" runat="server">
            <div class="row-fluid sortable">
                <div class="box span12">
                    <div class="box-header well" data-original-title>
                        <h2><i class="icon-edit"></i>Departman Ekle</h2>
                        <div class="box-icon">
                            <a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>
                            <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                            <a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
                        </div>
                    </div>
                    <div class="box-content">
                        <div class="form-horizontal">
                            <fieldset>
                                <legend>Departman Bilgilerini Giriniz</legend>
                                <div class="control-group">
                                    <label class="control-label" for="typeahead">Departman Adı </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtDepartman" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDepartman" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="date01">Açıklama</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtAciklama" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
                                    <asp:Label ID="lblDurum" runat="server" Text=""></asp:Label>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <!--/span-->
            </div>
        </asp:Panel>

        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header well" data-original-title>
                    <h2><i class="icon-user"></i>Departmanlar</h2>
                    <div class="box-icon">
                        <a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>
                        <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                        <a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-striped table-bordered bootstrap-datatable datatable">
                        <thead>
                            <tr>
                                <th>Branş Adı</th>
                                <th>Açıklama</th>
                                <th>Durum</th>
                                <th>İşlem</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptDepartmanlar" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="center"><%#Eval("DepartmanAdi") %></td>
                                        <td class="center"><%#Eval("Aciklama") %></td>
                                        <td class="center"><span class="<%# DurumKontrol(Eval("Aktif").ToString()) %>"><%#Eval("Aktif").ToString()=="1"?"Aktif":"Pasif" %></span></td>
                                        <td class="center">
                                            <a class="btn btn-warning" href="Departmanlar.aspx?id=<%#Eval("DepartmanID") %>">
                                                <i class="icon-edit icon-white"></i>
                                                Düzelt                                            
                                            </a>
                                            <a class="<%# AktifKontrol(Eval("Aktif").ToString(),"1") %>" href="Departmanlar.aspx?s=<%#Eval("DepartmanID") %>">
                                                <i class="<%# AktifKontrol(Eval("Aktif").ToString(),"2") %> icon-white"></i>
                                                <%#Eval("Aktif").ToString()=="1"?"Sil":"Aktif Et" %>
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            <!--/span-->
        </div>
    </asp:Panel>
</asp:Content>
