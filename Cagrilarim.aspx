<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Cagrilarim.aspx.cs" Inherits="IsTakipProgramı.Cagrilarim" ValidateRequest="false" %>

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
        <asp:Panel ID="pnlCagrilarim" runat="server">
            <div class="row-fluid sortable">
                <div class="box span12">
                    <div class="box-header well" data-original-title>
                        <h2><i class="icon-edit"></i>Çağrı Düzenle</h2>
                        <div class="box-icon">
                            <a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>
                            <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                            <a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
                        </div>
                    </div>
                    <div class="box-content">
                        <div class="form-horizontal">
                            <fieldset>
                                <legend>Çağrı Bilgileri</legend>
                                <div class="control-group">
                                    <label class="control-label" for="typeahead">Çağrı Numarası</label>
                                    <div class="controls">
                                        <asp:Label ID="lblCagriNumara" runat="server" Text="" class="input-xlarge uneditable-input"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="typeahead">Çağrı Sahibi</label>
                                    <div class="controls">
                                        <asp:Label ID="lblKullaniciAdi" runat="server" Text="" class="input-xlarge uneditable-input"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="date01">Çağrı Başlığı</label>
                                    <div class="controls">
                                        <asp:Label ID="lblBaslik" runat="server" Text="" class="input-xlarge uneditable-input"></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="date01">Çağrı Açıklaması</label>
                                    <div class="controls">
                                        <textarea class="cleditor" id="txtAciklama" rows="3" runat="server"></textarea>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="selectError3">Çağrıyı Üstlenen Kişi</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlUstlenenKisi" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="selectError3">Çağrıyı Aşaması</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlAsama" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="typeahead">Yapılan İşlemler</label>
                                    <div class="controls">
                                        <textarea class="cleditor" id="txtMetin" rows="3" runat="server"></textarea>
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
            </div>
        </asp:Panel>

        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header well" data-original-title>
                    <h2><i class="icon-user"></i>Çağrılar</h2>
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
                                <th>Çağrı Numarası</th>
                                <th>Açan Kişi</th>
                                <th>Çağrı Aşaması</th>
                                <th>Çağrı Durumu</th>
                                <th>İşlem</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptCagrilar" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="center"><%#Eval("CagriID") %></td>
                                        <td class="center"><%#Eval("KullaniciAdi") %></td>
                                        <td class="center"><%#Eval("Ad") %></td>
                                        <td class="center"><span class="<%# DurumKontrol(Eval("Aktif").ToString()) %>"><%#Eval("Aktif").ToString()=="1"?"Aktif":"Pasif" %></span></td>
                                        <td class="center">
                                            <a class="btn btn-warning" href="Cagrilarim.aspx?id=<%#Eval("CagriID") %>">
                                                <i class="icon-edit icon-white"></i>
                                                Düzelt                                            
                                            </a>
                                            <a class="<%# AktifKontrol(Eval("Aktif").ToString(),"1") %>" href="Cagrilarim.aspx?s=<%#Eval("CagriID") %>">
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
