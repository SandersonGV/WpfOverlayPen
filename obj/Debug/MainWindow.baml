   M S B A M L   `   `   `  ����  WpfOverlayPen    WpfOverlayPen.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6N   :d2http://schemas.microsoft.com/expression/blend/2008  6�   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6�     � Title$  
MainWindow��5   	   $��646.523��6   $��760.055��6-    � WindowStyle$
 None=�6=    � Topmost .  � AllowsTransparency .  � ShowInTaskbar .   � Icon$ Images/desenhar.png��5       J� IsManipulationEnabled . ��5   z   Z�  J� 	CacheMode 5      &   System.Windows.Media.BitmapCache  5	   
      EnableClearType . 	   SnapsToDevicePixels	 . 6-   .��5      � .+�5   
   �� -   5        
 ��Name$
 
paintboard��5       �� 
Background �	#0FFFFFFF6(   �� 5   
   -   5         ��Name$ btnlivre��5      $��64��6&   $��64��61   $	��Top=�6=   $
��Left=�6U   $��-657,-18,0,0q�6p    J� RenderTransformOrigin$ 0.5,0.5&�6�   $y�Hidden=�6�   ��5      �� 5       �� ImageSource$ Images/lapis.png��6    j� Stretch$ Uniform=�6<   5      �� 5   
   -   5        $ btnquadrado��5      $��64��6)   $��64��64   $	��Top=�6A   $
��Left=�6Y   $��-722,81,0,-81q�6t   $y�Hidden=�6�   ��5      �� 5      $ Images/retangulo.png��6   $ Uniform=�6@   5      �� 5   
   -   5        $ btnSair��5      $��64��6%   $��64��60   $	��Top=�6=   $
��Left=�6U   $��-668,265,0,-265q�6p   $y�Hidden=�6�   ��5      �� 5      $ Images/sair.png��6   $ Uniform=�6;   5      �� 5   
   -   5        $ 
btncirculo��5      $��64��6(   $��64��63   $	��Top=�6@   $
��Left=�6X   $��-828,21,0,-21q�6s   $y�Hidden=�6�   ��5      �� 5      $ Uniform=�6   $ Images/circulo.png��6/   5       �� 5!   
   -   5        $ btnLine��5!      $��64��6%   $��64��60   $	��Top=�6=   $
��Left=�6U   $��-798,172,0,-172q�6p   $y�Hidden=�6�   ��5"      �� 5#      $ Images/reta.png��6   $ Uniform=�6;   5%      �� 5&   
   -   5        $ 	btnconfig��5&      $��64��6'   $��64��62   $	��Top=�6?   $
��Left=�6W   $��-810,297,0,-297q�6r   $y�Hidden=�6�   ��5'      �� 5(      $ Images/config.png��6   $ Uniform=�6=   5*      �� 5+   
   -   5        $ 	btnapagar��5+      $��64��6'   $��64��62   $	��Top=�6?   $
��Left=�6W   $��-810,413,0,-413q�6r   $y�Hidden=�6�   ��5,      �� 5-      $ Images/apagar.png��6   $ Uniform=�6=   5/      �� 50   
   -	   5        $ 	btnvoltar��50      $��64��6'   $��64��62   $	��Top=�6>   $
��Left=�6V   $��-655,413,0,-413q�6q   $y�Hidden=�6�   ��51      �� 52      $ Images/voltar.png��6   $ Uniform=�6=   54      �� 55   
   -
   5        $ btnactv��55      $��64��6%   $��64��60   $��0q�6<   $
��Left=�6G   $	��Top=�6b   ��56      �� 57      $ Images/desenhar.png��6   $ Uniform=�6?   5:      �� 5<   
   -   5         ��Name$ 	configwin��5<      
���   �$��1q�68   $
��Left=�6L   $	��250��6g   $��Center=�6u   $	��400��6�   $��-613.876,251,0,-437q�6�    � UseLayoutRounding .   �� CornerRadius$ 20��6�   $y�Visible=�6�   ��5=      �� 5>      $ Images/configwin.png��6   ._�5@      � .+�5A      �� $��	Espessura��6   $
��Left=�6,   $��
292,45,0,0q�6G   $	��Top=�6[   �� 5B      $��	Opacidade��6   $
��Left=�6,   $��
290,93,0,0q�6G   $	��Top=�6[   A� 5C      -   5         A�Name$ btnVermelho��5C      
���  ��$
��Left=�6:   $��45��6U   $	��Top=�6b   $��36��6z   $��	29,44,0,0q�6�   6�   A� 5D      -   5        $ btnVerde��5D      
��� � �$
��Left=�68   $��45��6S   $	��Top=�6`   $��36��6x   $��
36,104,0,0q�6�   6�   A� 5E      -   5        $ btnAzul��5E      
����  �$
��Left=�67   $��45��6R   $	��Top=�6_   $��36��6w   $��
77,156,0,0q�6�   6�   A� 5F      -   5        $ 
btnAmarelo��5F      
��� ���$
��Left=�6<   $��45��6W   $	��Top=�6d   $��36��6|   $��132,177,0,0q�6�   6�   A� 5G      -   5        $ btnPreto��5G      
���   �$
��Left=�69   $��45��6T   $	��Top=�6a   $��36��6y   $��182,140,0,0q�6�   6�   � 5H      $��260,134,10,10q�6   .+�5I      A� -   5        $ demoball��5I      $	��100��60   $	��100��6=   
�������$��Center=�6V   $��Center=�6q   5J      �� 5K      -   5         ��Name$ minusopacidade��5K      $��Button��61   $
��Left=�6B   $��
255,84,0,0q�6]   $	��Top=�6q   $��40��6�      btnMenuStyle#���   6�   $��40��6�   ��6�   Z� ��6�   Z� ��5L      �� 5M      $ Images/diminuir.png��6%   $ UniformToFill=�6G   5O      �� 5P      -   5        $ btnplusopacidade��5P      $��Button��63   $
��Left=�6D   $��
354,84,0,0q�6_   $	��Top=�6s   $��40��6�   #���   6�   $��40��6�   ��6�   Z� ��6�   Z� ��5Q      �� 5R      $ Images/aumentar.png��6%   $ UniformToFill=�6G   5T      �� 5U      -   5        $ minusespessura��5U      $��Button��61   $
��Left=�6B   $��
255,37,0,0q�6]   $	��Top=�6q   $��40��6�   #���   6�   $��40��6�   ��6�   Z� ��6�   Z� ��5V      �� 5W      $ Images/diminuir.png��6%   $ UniformToFill=�6G   5Y      �� 5Z      -   5        $ btnplusespessura��5Z      $��Button��63   $
��Left=�6D   $��
354,37,0,0q�6_   $	��Top=�6s   $��40��6�   #���   6�   $��40��6�   ��6�   Z� ��6�   Z� ��5[      �� 5\      $ Images/aumentar.png��6%   $ UniformToFill=�6G   5^      5`      5a      5c      5d      