   M S B A M L   `   `   `  ����F  BTransaction, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Transaction.DesignTransaction.Design  5      !    Transaction.TransactionView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3design clr-namespace:Transaction.Design     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��280 �6   �� 5      $��2* �6   .+�5   
   �� $��42��6   $
��Wrap=�6    $	��Top=�6Z   $��32(�6r    �� TextAlignment$ Right=�6�   $��20,5,0,0q�6�   $��SketchFlow Print)�6�   $
��Left=�6�   $	��253��6�   ��64   �� *Company.SoftwareName+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFFFF9B3��6#      	Direction$ 70Q�65      ShadowDepth$ 0Q�6D   5      � 5   
   $��33.4,0,0,0.6q�6   $��1��6*   $��Right=�6:   .+�5      �� $
��Left=�6   $��42��63   $
��Wrap=�6?   $��Status ��6S   $	��Top=�6b   $��42��6z    �� LineStackingStrategy$ BlockLineHeight=�6�    �� 
LineHeight$ 37.333��6�   ���	#FFF7FEBC6�   �� 5      $
��Left=�6R   $��42��6m   $	��Top=�6z   $ BlockLineHeight=�6�   $ 37.333��6�   
�������$��16(�6�   $
��Auto=�6�   $��0,0,10,0q�6   ��6   ��  �� Path$ TransactionData.Status�	 �� Mode$	 OneWay=�6   �� 5      $
��Left=�6   $��42��63   $
��Wrap=�6?   $��Tran #��6S   $	��Top=�6a   $��42��6y   $ BlockLineHeight=�6�   $ 37.333��6�   ���	#FFF7FEBC6�   �� 5      $
��Left=�6]   $��42��6x   $	��Top=�6�   $ BlockLineHeight=�6�   $ 37.333��6�   
�������$��16(�6�   $
��Auto=�6�   $��0,0,10,0q�6+  ��6   �� $' !TransactionData.TransactionNumber�$	 OneWay=�6+  �� 5      $
��Left=�6   $��42��63   $
��Wrap=�6?   $��Customer��6S   $	��Top=�6c   $��55��6{   $ BlockLineHeight=�6�   $ 37.333��6�   ���	#FFF7FEBC6�   �� 5      $
��Left=�6`   $��42��6{   $	��Top=�6�   $ BlockLineHeight=�6�   $ 37.333��6�   
�������$��16(�6�   $
��Auto=�6�   $��0,0,10,0q�6.  ��6   �� $* $TransactionData.Customer.DisplayName�$	 OneWay=�6.  �� 5      $
��Time��6   $
��Left=�6$   $��42��6?   $
��Wrap=�6K   $	��Top=�6`   $��32��6x   $ BlockLineHeight=�6�   $ 37.333��6�   ���	#FFF7FEBC6�   �� 5      $
��Left=�6P   $��42��6k   $	��Top=�6x   $ BlockLineHeight=�6�   $ 37.333��6�   
�������$��16(�6�   $
��Auto=�6�   $��0,0,10,0q�6  ��6   �� $ TransactionData.Time�$	 OneWay=�6  �� 5      $��Opening Cashier��6   $
��Left=�6/   $��42��6J   $
��Wrap=�6V   $	��Top=�6k   $��91��6�   $ BlockLineHeight=�6�   $ 37.333��6�   ���	#FFF7FEBC6�   �� 5      $
��Left=�6_   $��42��6z   $	��Top=�6�   $ BlockLineHeight=�6�   $ 37.333��6�   
�������$��16(�6�   $
��Auto=�6�   $��0,0,10,0q�6-  ��6   �� $) #TransactionData.Cashier.DisplayName�$	 OneWay=�6-  �� 5      $��Station��6   $
��Left=�6'   $��42��6B   $
��Wrap=�6N   $	��Top=�6c   $��42��6{   $ BlockLineHeight=�6�   $ 37.333��6�   ���	#FFF7FEBC6�   �� 5      $
��Left=�6_   $��42��6z   $	��Top=�6�   $ BlockLineHeight=�6�   $ 37.333��6�   
�������$��16(�6�   $
��Auto=�6�   $��0,0,10,0q�6-  ��6   �� $) #TransactionData.Station.StationCode�$	 OneWay=�6-  �� 5       $��Store��6   $
��Left=�6%   $��42��6@   $
��Wrap=�6L   $	��Top=�6a   $��45��6y   $ BlockLineHeight=�6�   $ 37.333��6�   ���	#FFF7FEBC6�   �� 5!      $
��Left=�6U   $��42��6p   $	��Top=�6}   $��61��6�   $ BlockLineHeight=�6�   $ 37.333��6�   
�������$��16(�6�   $
��Auto=�6�   $��0,0,10,0q�6.  ��6   �� $ TransactionData.StoreCode�$	 OneWay=�6.  5"      F� 5#   
   $��2��6   �����3�PV�ў=#�y��	���	#FFF4F4F5$��3��6g   $��0,50.48,2.798,0q�6r   
 �� Stretch$

 Fill=�6�   
�������$	��Top=�6�   5$      5%      