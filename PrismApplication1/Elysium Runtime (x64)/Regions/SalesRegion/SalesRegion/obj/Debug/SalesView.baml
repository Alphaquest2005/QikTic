   M S B A M L   `   `   `  ����F  BSalesRegion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesRegionSalesRegion  5      M IRMSDataAccessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayerRMSDataAccessLayer 5      7 clr-namespace:SalesRegion.DesignSalesRegion.Design  5	          SalesRegion.SalesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:SalesRegion     5      Mdata<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayer     5      3design clr-namespace:SalesRegion.Design     5	      -   5        $	��424��5   �   $
��Left=�6�   $��Disabled=�6�   }�.    � 	Resources  5      %   SalesRegion.ArithmeticConverter   mathconverter  itemTemplate �� ElementName �� Path �� 	Converter �� ConverterParameter � ColumnDefinitions � RowDefinitions
 �� Top � LayoutTransform	 �� Triggers
 �� Binding �� RelativeSource �� Mode �� AncestorType �� Value �� Property �� Value � 	Resources.  (System.Windows.Media.Animation.CubicEase  Key7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode �� Triggers N� EnterActions g� Duration  ease W� EasingFunction �� 
TargetName �� TargetProperty	 W� To N� ExitActions  ListTemplate �� 
TargetType ��Name �� Padding J� SnapsToDevicePixels �� Triggers  P� Property! P� Value  ItemPanelTemplate  SalesItemStyle" �� 
TargetType# ]� 
Conditions$ �� Property% �� Value��%
  &	        &	      7   7  7  &	 �    &	 H    &	 �      5   
   6$   �� 5   
   .R�5      �� $��pcanvas��6   $��25��6%   $��0,0,0,0q�5      $	��400��5      |�.  ��5      �� $ maingrd��$ ActualHeight�8   $ ActualHeight+10��.+�5      � $��maingrd��6   $
��Auto��6(   }�.  $��5,5,5,5q�6K   .+�5      � $
��Auto��6   }�.  $��5,5,5,5q�6=    5      �� 5      $	��170 �6+   �� 5      $��50 �6+    5      �� 5      $��25 �6(   �� 5      $��25 �6(   .+�5$      �� $��0��6!   $��0��6.   $��2��6e   $��0,0,-0.6,11.8q�6y   $��2��6�   
���������6>   �� $ Item.Description�6�   �� 5%      $��0��6!   $��1��6.   $��5,0,-43.6,11.8q�6_   $��2��6w   
���������6>   �� $ 
Item.Price�6�   �� 5&      $��1��6!   $��0��6.   $��5,0,-43.6,11.8q�6[   $��2��6s   
���������6>   �� $ ItemId�6�   5'      � 5*      $��SalesPadGrd��6,   $��5,5,5,5q�6   $	��390��6?   $��80��6K   $ 50��6W   }�.  .+�5+      �� .��6   Edit Item...6+    5,      �� 5-      st��6)   ��53      �� 54      	 55      �� 56   "   
 57   '   �� $ 
IsSelected� �� $ FindAncestor=�" ��	 False5:   1   .a�5;   :   ��  � y�$ 	Collapsed=�6\   5>   '   5B      5D      5E      5F       5H      ��  5I      ease $ EaseOut=�6)   5J       5K      �� 5L      $
 True��6w   
 6   �� *
IsSelected+ �� $ ListBoxItemL� 5M      �� 5N      .��5O      �� .��5P   "   W� $ 0:0:0.3D�5Q   !   8  $ st��5S   !   $ ScaleY�5T   !   $	 2.3X�5U   !   5V      5W       5Y      �� 5Z      .��5[      �� .��5\   "   W� $ 0:0:0.3D�5]   !   8  $ st��5_   !   $ ScaleX�5`   !   $ 1X�5a   !   5b      5c      5e      �� 5f      $
 True��6w   
 6   �� *
IsSelected+ �� $ ListBoxItemL�5h      5l      �� 5m   
   " ��6/   .R�5n      �� $ Bd��6   #��z��6!   #��z��6M   $ 1q�6�    . ._�5o      �� # z 6!   5p       5q      P� 5r        � {�! .  5t      5v      �� 5x   
   .R�5y      �� $
��auto��6   $
��Auto��6'   }�.  $��0,0,0,0q�6J   5{      5|      �� 5}   
   "" ��6'   	 5~   
   ]� 5      # 5�      �� 5�      $ �@��AlternationIndex$% 1��6I   �� 5�      $ �@��
IsSelected% .  66   �� 5�      $ �@J�IsMouseOver% .  67   ./�5�      ��  � �� �	#EE6868686/   5�      5�      5�      .��5�      �� $��
5,5,4,-705q�6   & �� Orientation$& Vertical=�6%   .+�5�   
   � $
��Auto��6   ���	#FFA0A0A0$��	0,0,0.2,0q�64     5�      ' �� DataType  RMSDataAccessLayer.Ticket*  $RMSDataAccessLayer.QuickPrescription( �� 
LineHeight) �� TextAlignment 
 HVLogo%  RMSDataAccessLayer.Prescription* �� StringFormat+ �� ValidatesOnDataErrors��%^  (��       5�      *, +)(�� 2     5�      *, +)(�� �    5�      *, +)�� 5�      "'  6   .R�5�      � 5�      �� 5�      "'  6   .R�5�      � .+�5�      �� $��
Quick Sale��6$   $��
139,53,0,0q�66   ���	#FF144000$( 12��6a   $��39��6q   $	��Top=�6}   $
��Left=�6�   $	��131��6�   $��Pristina)�6�   $��36(�6�   �� 5�      $ ��Hills and Valleys Pharmacy��6$   $��	0,0,0.2,0q�6F   $��Myanmar Text)�6Y   $) Center=�6s   $��22(�6�   ���	#FF085609$��28��6�   $	��Top=�6�   �� 5�      $+��%Your health is our business - We Care��6$   $��0,28,-0.8,0q�6Q   $��Bradley Hand ITC)�6f   $) Center=�6�   $��16(�6�   ���	#FF015002$��20��6�   $	��Top=�6�   �� 5�      $��12,5,358.8,0q�6    #���  66   $
��Fill=�6X   $��43��6g   $	��Top=�6s   5�      5�      �� 5�      "'  6   .R�5�      � .+�5�      �� $��Prescription��6   $��
152,42,0,0q�60   ���	#FF144000$( 12��6[   $��39��6k   $	��Top=�6w   $
��Left=�6�   $	��103��6�   $��Pristina)�6�   $��24(�6�   �� 5�      $��12,75,130.8,0q�6�   $��24��6�   $	��Top=�6�   $��14(�6�   $��Calibri)�6�   ��6$   �� $ Doctor.DisplayName�$* 	Doctor: 0��+ . 6�   �� 5�      $��12,99,130.8,0q�6�   $��27��6�   $	��Top=�6�   ��6$   �� $ Patient.DisplayName�$* 
Patient: 0��+ . 6�   �� 5�      $��
343,99,0,0q�6:   
���   ����	#FFF4F4F4$
��Left=�6x   $��63��6�   $��32��6�   $	��Top=�6�   ��6"   �� *Repeat+6�   �� 5�      $
��Rep.��6$   $��310,105,0,0q�60   ���	#FF202020$( 12��6\   $��26��6l   $	��Top=�6x   $
��Left=�6�   $��28��6�   �� 5�      $ ��Hills and Valleys Pharmacy��6$   $��	0,0,0.2,0q�6F   $��Myanmar Text)�6Y   $) Center=�6s   $��22(�6�   ���	#FF085609$��28��6�   $	��Top=�6�   �� 5�      $+��%Your health is our business - We Care��6$   $��0,28,-0.8,0q�6Q   $��Bradley Hand ITC)�6f   $) Center=�6�   $��16(�6�   ���	#FF015002$��20��6�   $	��Top=�6�   �� 5�      $��12,5,358.8,0q�6   #���  6.   $
��Fill=�6P   $��43��6_   $	��Top=�6k   5�      5�      5�      .+�5�      �� -   5        $��SalesHeader��5�   !   ��64   �� $ TransactionData�5�      �� 5�   
   -   5        , ��Name$, ppcan��5�      ���	#FF424242$	��415��67   $��	0,0,0.2,0q�6C   $
��1000��6V   |�.  .+�5�      �� -   5        - ��Name$- SalesLst��5�      #���  5�      #���  5�      #��[ 5�      . �� AlternationCount$. 2��5�      #���  5�      / �� Left$/ 3��66   $	 153��6F   $	��410��6W   }�.  $
��Auto��6x   ��5�      �� *$"TransactionData.TransactionEntries+5�   x      SalesRegion.SalesTaskPad  5�      -   5        0  Name$0 SalesPad��5�   !   $
��Auto��6�   $
��Auto��6�   1 +� FocusedElement1 63   .   (SalesRegion.FirstFocusedElementExtension  2 � DataContext2 6n   �� *SelectedItem+$ SalesLst��5�      5�      5�      5�      