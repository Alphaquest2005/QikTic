   M S B A M L   `   `   `  ����P  LElysium, Version=1.5.817.0, Culture=neutral, PublicKeyToken=f8966962afac6b6dD/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls  5      L HQuickSalesManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuickSalesManagerQuickSalesManager 5      "   QuickSalesManager.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5      7params*http://schemas.codeplex.com/elysium/params   5      +localclr-namespace:QuickSalesManager   5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6G   :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6?   -   5           Elysium.Controls.Window   Name$  Window��5         Elysium.Parameters.Design   Theme$
 DarkX�5	          Elysium.Parameters.Manager   Theme$
 DarkX�5
       � Title$ 
MainWindow��5      $	��640��5      $	��480��6    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ CanResizeWithGrip=�6A    � WindowStyle$
 None=�6`   ���	#FF3F3F3F � WindowState$ 	Maximized=�6�   .��5   
   � -   5         �Name$ 
LayoutRoot��5      .+�5   
      QuickSalesManager.MainView  $��	0,0,0,105q�6   �� 5      $��80��6   $��0,0,0,25q�6!   $��Bottom=�63   ���	#FF4A4A4A$��2q�6f   ���	#FF434343	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      ._�5      � -   5        $ 	FooterBar��5      $��80��6g   .+�5      �� $��71��6   $	��Top=�6)   $��Right=�6A   $��
0,0,48.6,0q�6]   $��62��6q   $��Segoe UI Symbol)�6|   $��40(�6�   $	����6�   ��6�   Z� .  (System.Windows.Interactivity.Interaction
   Triggers
 5      /  )System.Windows.Interactivity.EventTrigger  5          	EventName$ Click��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5!   "   >	  8Microsoft.Expression.Interactivity.Core.CallMethodAction	   	  
MethodName$ ViewModelMethod��66    	  TargetObject 6S   �� 5"      5%      �� 5&      $��63��6   $	��Top=�6)   $��Right=�6A   $��0,3,451.6,0q�6]   $��55��6r   $��Segoe UI Symbol)�6}   $��40(�6�   $	����6�   ��6�   Z� 
 5'        5(      $ Click��6-   . 5)   "   	  $ ViewModelMethod��66    6S   �� 5*      5-      �� 5.      $��Ticket��6    $��Right=�6.   $��20��6J   $��0,0,454.6,-2q�6V   $
��Wrap=�6l   $��Bottom=�6�   $��65��6�    �� TextAlignment$ Center=�6�   �� 5/      $��63��6   $	��Top=�6)   $��Right=�6A   $��0,2,326.6,0q�6]   $��55��6r   $��Segoe UI Symbol)�6}   $��40(�6�   $	����6�   ��6�   Z� 
 50        51      $ Click��6-   . 52   "   	  $ ViewModelMethod��66    6S   �� 53      56      �� 57      $
��Pass��6    $��Right=�6,   $��20��6H   $��0,0,329.6,-1q�6T   $
��Wrap=�6j   $��Bottom=�6   $��65��6�   $ Center=�6�   �� 58      $��63��6   $	��Top=�6)   $��Right=�6A   $��0,1,183.4,0q�6]   $��55��6r   $��Segoe UI Symbol)�6}   $��40(�6�   $	����6�   ��6�   Z� 
 59        5:      $ Click��6-   . 5;   "   	  $ ViewModelMethod��66    6S   �� 5<      5?      �� 5@      $��Cashiers��6    $��Right=�60   $��20��6L   $��0,0,183.6,-1q�6X   $
��Wrap=�6n   $��Bottom=�6�   $��65��6�   $ Center=�6�    J� RenderTransformOrigin$ 
0.535,1.32&�6�   5A      5B      � 5C   
   -   5        $ 	HeaderBar��5C      $��70��6"   $��0,0,0,0q�6.   $	��Top=�6?   ���	#00000000.+�5D      � -   5        
������ 5D   R   �� 5E      $��64��6   $	��Top=�6!   $
��Left=�69   $��	14,4,0,-8q�6T   $��60��6g   $��Segoe UI Symbol)�6r   $��40(�6�   $	����6�   $y�Hidden=�6�   ��6�   Z� 
 5F        5G      $ Click��6%   . 5H      	  $ ViewModelMethod��6.    6K   �� 5I      5L      �� 5M      -   5        $	����5M      $��Right=�6(   $��50��6D   $	��Top=�6P   $��35��6h   $��Segoe UI Symbol)�6s   $��24(�6�   $��
0,10,0.4,0q�6�   ��6�   Z� 6�   5N      5O      5T      