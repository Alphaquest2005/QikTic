   M S B A M L   `   `   `  ����M  IRMSDataAccessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayerRMSDataAccessLayer  5      F BSalesRegion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SalesRegion.DesignSalesRegion.Design 5      )clr-namespace:SalesRegionSalesRegion 5         SalesRegion.SalesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Mdata<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayer     5      3design clr-namespace:SalesRegion.Design     5      +localclr-namespace:SalesRegion     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5        $	��424��5	      $
��Left=�5
      }�.  $��Disabled=�5        � 	Resources  5      %  SalesRegion.ArithmeticConverter   mathconverter  ListTemplate �� 
TargetType ��Name �� Padding J� SnapsToDevicePixels �� Triggers P� Property P� Value  ItemPanelTemplate  SalesItemStyle �� 
TargetType	 �� Triggers
 ]� 
Conditions �� Property �� Value �� Property �� Value��%�  &	        &	      &	 �     &	 W      5   
   6$   �� 5   
   " ��6/   .R�5      �� $ Bd��6   #��z��5      #��z��5      $ 1q�5       . ._�5      �� # z 6!   5       5      P� 5       � {� .  5      5!      �� 5#   
   .R�5$      �� $
��auto��6   $
��Auto��5%      $��0,0,0,0q�5&      }�.  5'      5(      �� 5)   
   " ��6'   	 5*      ]� 5+      
 5,      �� 5-       �@��AlternationIndex$ 1��6M   �� 5.       �@��
IsSelected .  6:   �� 5/       �@J�IsMouseOver .  6;   ./�51      ��  � �� �	#EE68686863   52      54      58      .��5:      �� $��
5,5,4,-705q�6    �� Orientation$ Vertical=�6%   .+�5;   
   � $
��Auto��6   $��	0,0,0.2,0q�5<      ���	#FFA0A0A0  5>       �� DataType   RMSDataAccessLayer.Ticket��%G   (��       5?      *, +)�� 6   "  6   .R�5@      � 5A      5C      .+�5D      �� -   5        $��SalesHeader��5D      ��60   ��  �� Path$ TransactionData�5H      �� 5I   
   -   5         ��Name$ ppcan��5I      $	��415��5J      $
��1000��5K      $��	0,0,0.2,0q�5L      ���	#FF424242|�.  .+�5P        SalesRegion.SalesTaskPad  -   5          Name$ SalesPad��5P   !   $
��Auto��5Q   !   $
��Auto��5R   !    � DataContext 5S   !   �� *SelectedItem+ �� ElementName$ SalesLst�� +� FocusedElement 5U   !   .  (SalesRegion.FirstFocusedElementExtension  5X      5[      5]      5_      