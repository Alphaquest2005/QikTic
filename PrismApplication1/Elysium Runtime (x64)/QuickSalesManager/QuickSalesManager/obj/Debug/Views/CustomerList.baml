   M S B A M L   `   `   `  ����L  HQuickSalesManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuickSalesManagerQuickSalesManager  5      M IRMSDataAccessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayerRMSDataAccessLayer 5      $    QuickSalesManager.CustomerList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:QuickSalesManager     5      Mdata<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayer     5      $	��470��5      $	��365��6+     � 	Resources  5	      *   $QuickSalesManager.CustomersViewModel   CustomerViewModel �� DataType"  RMSDataAccessLayer.Customers � RowDefinitions � ColumnDefinitions��%�  &	        (��      5      *, +)  5
   
   6#   �� 5   
   "  6   .R�5      � ���	#FFAA9999$
��80px��6*   $	��5pxq�68    5      �� 5      $	��35* �6$   �� 5      $	��30* �6$   �� 5      $	��20* �6$    5      �� 5      $��8* �6'   �� 5      $��8* �6'   �� 5      $	��31* �6'   .+�5      �� $��2��69   $
��Left=�6I   $
��Wrap=�6d   $	��Top=�6x   $��35��6�   $	��265��6�   $��Segoe UI Light)�6�   $��20(�6�   ��6   �� *DisplayName+6�   �� 5      $��2��69   $
��Left=�6I   $
��Wrap=�6d   $	��Top=�6y   $��30��6�   $	��265��6�   $��Segoe UI Light)�6�   $��17(�6�   $��0,35,0,0q�6�   $��2��6�   ��6   �� *PhoneNumber+6�   �� 5      $��2��6:   $
��Left=�6J   $��1��6e   $
��Wrap=�6r   $	��Top=�6�   $��25��6�   $	��265��6�   $��Segoe UI Light)�6�   $��13(�6�   $��0,28.8,0,-9q�6�   $��2��6�   ��6   �� *CustomerType+6�   �� 5      $��1��64   $
��Left=�6D   $��55��6_   $��	10,14,0,0q�6k   $��3��6~   $
��Wrap=�6�   $	��Top=�6�   $��55��6�   $��Segoe UI Symbol)�6�   $��40(�6�   ��6   �� *Symbol+6�   5      5       5!      .��5"      �  � DataContext 6   ��  �� Source# [   �� Path$ CustomerList�.+�5#   
   �� $��	Customers��6   $��10,0,0,0q�6%   $
��20px(�67   $��40��6G   $
��Left=�6S   $	��Top=�6n   $��Segoe UI Light)�6�   �� 5$   
   ���	#00000000$ �� IsSynchronizedWithCurrentItem$
 TrueY�6C   $��0,40,0,0q�6i   ��6   �� 5&      5(      5)      