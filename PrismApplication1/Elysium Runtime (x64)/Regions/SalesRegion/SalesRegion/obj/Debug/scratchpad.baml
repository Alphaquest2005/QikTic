   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35X@clr-namespace:System.Windows.Data;assembly=PresentationFrameworkSystem.Windows.Data 5      F BSalesRegion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesRegionSalesRegion 5	      M IRMSDataAccessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayerRMSDataAccessLayer 5
         SalesRegion.scratchpad   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      Owd@clr-namespace:System.Windows.Data;assembly=PresentationFramework     5      +localclr-namespace:SalesRegion     5	      Mdata<clr-namespace:RMSDataAccessLayer;assembly=RMSDataAccessLayer     5
      $	��400��5      $	��255��6+   ���#003300.��5      � $��Hidden=�6   $��Hidden=�6?     � RowDefinitions  5   
   �� 5      $	��39* �6   �� 5      $
��136* �6   �� 5      $	��15* �6   .+�5   
   �� $
��Left=�6   $��30��6+   $	��Top=�67   $��30��6O    
  HVLogo#���   6Z   $��3,3,0,0q�6|   $��UniformToFill=�6�   �� 5   
   $��38,2,79,9.895q�6�   $��Calibri)�6�   $��16(�6�   
���   �$
��Wrap=�6�   ��6   �� *;9SalesVM.TransactionData.Station.Store.Company.CompanyName+ �� RelativeSource ��  �� AncestorType" >�6�   �� 5   
   $
��Wrap=�6�   $��46,17,71,0.895q�6�   $��Buxton Sketch)�6�   
���   ���6   �� *53SalesVM.TransactionData.Station.Store.Company.Motto+ �� " >�6�   �� 5   
   $
��Left=�6�   $��11��6�   $��	212,3,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��69��6  $��Calibri)�6  $	��7.5(�6$   �� TextAlignment$ Right=�63  
���   ���6   �� *75SalesVM.TransactionData.Station.Store.Company.Address+ �� " >�6I  �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $��1��6@   $��0,33,0,0q�6K   
���   �$	��Top=�6l   $	��286��6�   �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $��1��6@   $��0,136.067,0,0q�6K   
���   �$	��Top=�6q   $	��286��6�   $��2��6�   $��1��6�   �� 5   
   $
��Left=�6   $��14��6/   $��1��6;   $
��Wrap=�6H   $=��7Warning: Any Severe reaction please contact Your Doctor��6\   $	��Top=�6�   $	��283��6�   $��Arial)�6�   $��8(�6�   $
��Bold"�6�   $ Center=�6�   
���   �$��-7,119.105,0,0q�6  $��2��63  � 5   
   $��	3,19,5,35q�6   $��1��6"   .+�5      �� ���	#FFF4F4F5$
��Left=�6)   $��1��6D   
���   �$	��Top=�6^   $	��216��6v   $��0,0,0,0q�6�   �� 5      ���	#FFF4F4F5$
��Left=�6)   $��1��6D   $��0,23,0,0q�6O   
���   �$	��Top=�6p   $	��216��6�   �� 5      -   5         ��Name$ 	DosageTxt��5   0   $
��Left=�6C   $��0,37,0,-13.316q�6^   $
��Wrap=�6v   $	��278��6�   $��Calibri)�6�   $��10(�6�   
���   ���6   �� *Dosage+6�   �� 5      $
��Left=�6:   $��23��6U   $��36,0,0,0q�6a   $
��Wrap=�6s   $	��Top=�6�   $	��176��6�   $��Calibri)�6�   $��16(�6�   
���   ���6   �� *Item.Description+6�   �� 5      $
��Left=�6C   $��22��6^   $��0,1,0,0q�6j   $
��Wrap=�6{   $	��Top=�6�   $��23��6�   $��Calibri)�6�    J� RenderTransformOrigin$ 0.701,0.758&�6�   $��14(�6�   
���   ���6   �� *
Quantity+ �� StringFormat$ n0��6�   �� 5       $
��Left=�6?   $��14��6Z   $��196,81,0,-27.316q�6f   $
��Wrap=�6�   $	��Top=�6�   $��39��6�   $��Calibri)�6�   $��10(�6�   
���   ���6   �� *Price+$ c��6�   �� 5!      $
��Left=�6@   $��16��6[   $��
240,81,0,0q�6g   $
��Wrap=�6{   $	��Top=�6�   $��41��6�   $��Calibri)�6�   $��14(�6�   ���	#FF873838��6   �� *TransactionData.Repeat+6�   �� 5"      $
��Left=�6d   $��10,79,0,-29.316q�6   $
��Wrap=�6�   $	��181��6�   $��Calibri)�6�   
���   �$��18��6�   $	��Top=�6�   ��6   �� *
ExpiryDate+$% Product Expires:{0:MMM-dd-yyyy}��6�   5#      �� 5&   
   $
��Left=�6�   $��10��6�   $��3,33,0,0q�6�   $��2��6�   $
��Wrap=�6�   $	��Top=�6�   $	��127��6
  $��Calibri)�6  $��8(�6+  
���   ���6   �� *,*SalesVM.TransactionData.Doctor.DisplayName+ �� " >�68  �� 5'   
   $
��Left=�6�   $��9��6�   $��	3,8.8,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��232��6�   $��Calibri)�6  $��8(�6  $��1��6'  
���   ���6   �� *-+SalesVM.TransactionData.Patient.ContactInfo+ �� " >�64  �� 5(   
   $
��Left=�6�   $��9��6�   $��
150,34,0,0q�6�   $��2��6�   $
��Wrap=�6�   $	��Top=�6�   $��70��6�   $��Calibri)�6  $��8(�6  
���   ���6   �� *SalesVM.TransactionData.Time+ �� " >�6)  �� 5)   
   $
��Left=�6�   $��11��6�   $��
212,16,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��69��6	  $��Calibri)�6  $	��7.5(�6)  $ Right=�68  
���   ���6   �� *;9SalesVM.TransactionData.Station.Store.Company.PhoneNumber+ �� " >�6N  5,      5.      