   M S B A M L   `   `   `  ����L  HQuickSalesManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuickSalesManagerQuickSalesManager  5      M IRMSDataAccessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayerRMSDataAccessLayer 5      $    QuickSalesManager.CustomerPass   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:QuickSalesManager     5      Mdata<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayer     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6S     � 	Resources  5      *   $QuickSalesManager.CustomersViewModel   CustomerViewModel��%   &	          5   
   6#   5      .��5      �  � DataContext 6   ��  �� Source# [  .+�5   
   &   System.Windows.Controls.DataGrid  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6K      CanUserAddRows .    CanUserDeleteRows .    CanUserResizeColumns . $��10,40,10,10q�6�   ���	#FF3E3E3E
�������   AutoGenerateColumns .  ��6   ��   DataGridStyle# [ ��6�   �� *Customer.Pass+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Pass Number��6g     TextBoxStyle11  +System.Windows.Controls.DataGridBoundColumn
   EditingElementStyle#
 �  6|      Binding 6%   �� *
PassNumber+   ClipboardContentBinding 6D   Z� 6|     5      $	 
Start Date��6v   #
 �  6�    6%   �� *	StartDate+ �� StringFormat$ d�� 6S   Z� 6�     5      $	 End Date��6t   #
 �  6�    6%   �� *	EndDate+$ d�� 6Q   Z� 6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $	 	Free Pass��6i    6)   �� *
FreePass+ 6F   Z� 6i     5      $	 Status��6N   #
 �  6^    6%   �� *Status+ �� Mode$ OneWay=�6^   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ CellEditEnding��6   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5      >
  8Microsoft.Expression.Interactivity.Core.CallMethodAction
   
  
MethodName$ 
UpdateSave��6F    
  TargetObject 6!   �� $ OneWay=�6F   5        5      $ 
MouseLeave��6!   . 5      
  $ 
UpdateSave��6O    6*   �� $ OneWay=�6O   5       5"      �� 5#   
   $��Passes��6   $��10,0,0,0q�6"   $
��20px(�64   $��40��6D   $
��Left=�6P   $	��Top=�6k   $��Segoe UI Light)�6�   5%      5&      