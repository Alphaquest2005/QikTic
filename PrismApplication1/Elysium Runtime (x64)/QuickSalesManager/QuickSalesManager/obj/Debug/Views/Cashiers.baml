   M S B A M L   `   `   `  ����L  HQuickSalesManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuickSalesManagerQuickSalesManager  5           QuickSalesManager.Cashiers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bic9http://schemas.microsoft.com/expression/2010/interactions  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      +localclr-namespace:QuickSalesManager  5      $	��285��5   #     � 	Resources  5      )   #QuickSalesManager.CashiersViewModel   CashiersViewModel��%   &	          5   
   6"   5      .��5      � -   5         �Name$ 
CashierGrd��5      $��
0,5,-0.2,0q�6a    � DataContext 6   ��  �� Source# [   � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      �� 5      .+�5   
   �� $	����6   $��Center=�6O   $��35��6l   $��10,2.4,102.4,0q�6x   $��6��6�   $	��Top=�6�   $��30��6�   $��20(�6�   $��Segoe UI Symbol)�6�   ��6$   �� *MovePreviousCashierCmd+6�   �� 5    
   $	����6   $��Center=�6K   $��35��6h   $��101.6,4.4,0,0q�6t   $��6��6�   $	��Top=�6�   $��30��6�   $��20(�6�   $��Segoe UI Symbol)�6�   $��1��6�   ��6$   �� *MoveNextCashierCmd+6�   �� 5"   
   $
��Left=�6   $��10,13.857,0,0q�6/   $
��Wrap=�6F   $��
First Name��6Z   $	��Top=�6l   $��22��6�   $��71��6�   $��13(�6�   $��1��6�   �� 5#      $��1��6A   $
��Left=�6Q   $��23��6l   $��9.4,12.857,0,0q�6x    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��13(�6�   $��1��6�   ��6   ��  �� Path$ CashierLst.FirstName�6�   �� 5$      $
��Left=�6   $��10,13.714,0,0q�63   $��2��6J   $
��Wrap=�6W   $��	Last Name��6k   $	��Top=�6|   $��71��6�   $��15��6�   $��13(�6�   �� 5%      $
��Left=�6   $��10,14.571,0,0q�63   $��3��6J   $
��Wrap=�6W   $	��Top=�6k   $��71��6�   $��15��6�   $��13(�6�   �� 6�   $�Address��6�   6�   �� 5&      $
��Left=�6   $��10,14.429,0,0q�63   $��4��6J   $
��Wrap=�6W   $��Phone Number��6k   $	��Top=�6   $��91��6�   $��15��6�   $��13(�6�   �� 5'   
   $��1��67   $
��Left=�6G   $��23��6b   $��9.4,13.714,0,0q�6n   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6�   $��13(�6�   ��6   �� *CashierLst.LastName+6�   �� 5(   
   $��1��66   $
��Left=�6F   $��23��6a   $��9.4,13.571,0,0q�6m   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��3��6�   $��13(�6�   ��6   �� *CashierLst.Address+6�   �� 5)   
   $��1��6:   $
��Left=�6J   $��23��6e   $��9.4,15.429,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��4��6�   $��13(�6�   ��6   �� *CashierLst.PhoneNumber+6�   �� 5*   
   $	����6   $��Center=�6F   $��35��6c   $��130,2.4,124.8,0q�6o   $��6��6�   $	��Top=�6�   $��30��6�   $��20(�6�   $��Segoe UI Symbol)�6�   $��2��6�   ��6$   �� *AddCashierCmd+6�   �� 5+   
   $��InActive��6=   $��1��6P   $��Center=�6`   $��22��6}   $��7.4,14.286,25.2,5.857q�6�   $��5��6�   $��Center=�6�   $	��110��6�   $��13(�6�    d� 	IsChecked 6   �� *CashierLst.InActive+6�   �� 5,   
   $��Cashiers��6   $��6,0,0,0q�6$   $
��20px(�65   $��40��6E   $
��Left=�6Q   $	��Top=�6l   $��Segoe UI Light)�6�   $��2��6�   $	��265��6�   5-      50      