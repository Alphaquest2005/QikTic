   M S B A M L   `   `   `  ����L  HQuickSalesManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuickSalesManagerQuickSalesManager  5      '    !QuickSalesManager.CustomerDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bic9http://schemas.microsoft.com/expression/2010/interactions  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      +localclr-namespace:QuickSalesManager  5      $	��285��5   #     � 	Resources  5      *   $QuickSalesManager.CustomersViewModel   CustomerViewModel��%   &	          5   
   6#   5      .��5      � -   5         �Name$ CustomerDetailsGrd��5      $��
0,0,-0.2,0q�6i    � DataContext 6'   ��  �� Source# [   � RowDefinitions 5      �� 5      $	��36* �6   �� 5      $	��36* �6   �� 5      $	��36* �6   �� 5      $	��36* �6    �� 5      $	��35* �6    �� 5      $	��36* �6    �� 5      $	��35* �6    �� 5      $	��52* �6     � ColumnDefinitions 5      �� 5      �� 5      .+�5!   
   �� $	����6   $��Center=�6Q   $��35��6n   $��15,14.656,92.6,0q�6z   $��7��6�   $	��Top=�6�   $��35��6�   $��20(�6�   $��Segoe UI Symbol)�6�   ��6$   �� *MovePreviousCustomersCmd+6�   �� 5"   
   $	����6   $��Center=�6M   $��35��6j   $��97.4,14.656,15.2,0q�6v   $��7��6�   $	��Top=�6�   $��30��6�   $��20(�6�   $��Segoe UI Symbol)�6�   $��1��6�   ��6$   �� *MoveNextCustomersCmd+6�   �� 5$   
   $
��Left=�6   $��10,3.238,0,0q�6/   $
��Wrap=�6E   $��
First Name��6Y   $	��Top=�6k   $��22��6�   $��71��6�   $��13(�6�   $��Segoe UI Light)�6�   $��1��6�   �� 5%   
   $��1��6W   $
��Left=�6g   $��23��6�   $��9.4,2.238,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��13(�6�   $��1��6�   ��6   ��  �� Path$ Customer.FirstName� �� NotifyOnSourceUpdated . 6�   �� 5&      $
��Left=�6   $��10,3.477,0,0q�63   $��2��6I   $
��Wrap=�6V   $��	Last Name��6j   $	��Top=�6{   $��71��6�   $��15��6�   $��13(�6�   $��Segoe UI Light)�6�   �� 5'      $
��Left=�6   $��10,3.715,0,0q�63   $��3��6I   $
��Wrap=�6V   $	��Top=�6j   $��71��6�   $��15��6�   $��13(�6�   $��Segoe UI Light)�6�   �� 6�   $�Address��6�   6�   �� 5(      $
��Left=�6   $��10,3.954,0,0q�63   $��4��6I   $
��Wrap=�6V   $��Phone Number��6j   $	��Top=�6~   $��91��6�   $��15��6�   $��13(�6�   $��Segoe UI Light)�6�   �� 5)   
   $��1��65   $
��Left=�6E   $��23��6`   $��9.4,3.477,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6�   $��13(�6�   ��6   �� *Customer.LastName+6�   �� 5*   
   $��1��64   $
��Left=�6D   $��23��6_   $��9.4,2.715,0,0q�6k   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��3��6�   $��13(�6�   ��6   �� *Customer.Address+6�   �� 5+   
   $��1��68   $
��Left=�6H   $��23��6c   $��9.4,4.954,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��4��6�   $��13(�6�   ��6   �� *Customer.PhoneNumber+6�   �� 5,   
   $	����6   $��Center=�6H   $��35��6e   $��130,14.656,125.2,0q�6q   $��7��6�   $	��Top=�6�   $��30��6�   $��20(�6�   $��Segoe UI Symbol)�6�   $��2��6�   ��6$   �� *AddCustomersCmd+6�   �� 5-   
   $��InActive��6;   $��1��6N   $��12.4,8.424,20.2,8.344q�6^   $��6��6}   $��13(�6�   $��Segoe UI Light)�6�   	 d� 	IsChecked	 6   �� *Customer.InActive+6�   �� 5.   
   $��
0,-1,0.2,0q�6   $
��Wrap=�6(   $��Customer Details��6<   $��2��6T   $��Segoe UI Light)�6h   $��20(�6�   $��31��6�   $	��Top=�6�   �� 5/   
   $
��Left=�6   $��10,5.185,0,0q�6/   $��5��6E   $
��Wrap=�6R   $��Customer Type��6f   $	��Top=�6{   $��91��6�   $��22��6�   $��13(�6�   $��Segoe UI Light)�6�   �� 50   
   $��1��69   $
��Left=�6I   $��23��6d   $��9.4,6.185,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��5��6�   $��13(�6�   ��6   �� *Customer.CustomerType+6�   51      54      