   M S B A M L   `   `   `  ����   WpfOverlayPen    WpfOverlayPen.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Hi:http://schemas.microsoft.com/expression/2010/interactivity     Hei9http://schemas.microsoft.com/expression/2010/interactions       � Title$  
MainWindow��$��64��$��64�� � WindowStyle$
 None=� � Topmost .  � AllowsTransparency .  � ShowInTaskbar .   � Icon$ Images/desenhar.png�� J� IsManipulationEnabled . ��Z�  J� 	CacheMode &   System.Windows.Media.BitmapCache     EnableClearType . 	   SnapsToDevicePixels	 . .��� .+��� -   
 ��Name$
 
paintboard�� �� 
Background �	#0FFFFFFF�� -    ��Name$ btnlivre��$��64��$��64��$	��Top=�$
��Left=�$��-657,-18,0,0q� J� RenderTransformOrigin$ 0.5,0.5&�$y�Hidden=�����  �� ImageSource$ Images/lapis.png�� j� Stretch$ Uniform=��� -   $ btnquadrado��$��64��$��64��$	��Top=�$
��Left=�$��-722,81,0,-81q�$y�Hidden=����� $ Images/retangulo.png��$ Uniform=��� -   $ btnSair��$��64��$��64��$	��Top=�$
��Left=�$��-668,265,0,-265q�$y�Hidden=����� $ Images/sair.png��$ Uniform=��� -   $ 
btncirculo��$��64��$��64��$	��Top=�$
��Left=�$��-828,21,0,-21q�$y�Hidden=����� $ Uniform=�$ Images/circulo.png���� -   $ btnLine��$��64��$��64��$	��Top=�$
��Left=�$��-798,172,0,-172q�$y�Hidden=����� $ Images/reta.png��$ Uniform=��� -   $ 	btnconfig��$��64��$��64��$	��Top=�$
��Left=�$��-810,297,0,-297q�$y�Hidden=����� $ Images/config.png��$ Uniform=��� -   $ 	btnapagar��$��64��$��64��$	��Top=�$
��Left=�$��-810,413,0,-413q�$y�Hidden=����� $ Images/apagar.png��$ Uniform=��� -	   $ 	btnvoltar��$��64��$��64��$	��Top=�$
��Left=�$��-655,413,0,-413q�$y�Hidden=����� $ Images/voltar.png��$ Uniform=��� -
   $ btnactv��$��64��$��64��$��0q�$
��Left=�$	��Top=����� $ Images/desenhar.png��$ Uniform=��� -    ��Name$ 	configwin��
���   �$��1q�$
��Left=�$	��250��$��Center=�$	��400��$��-613.876,251,0,-437q� � UseLayoutRounding .   �� CornerRadius$ 20��$y�Hidden=����� $ Images/configwin.png��._�� .+��� $��	Espessura��$
��Left=�$��
292,45,0,0q�$	��Top=��� $��	Opacidade��$
��Left=�$��
290,93,0,0q�$	��Top=�A� -    A�Name$ btnVermelho��
���  ��$
��Left=�$��45��$	��Top=�$��36��$��	29,44,0,0q�A� -   $ btnVerde��
��� � �$
��Left=�$��45��$	��Top=�$��36��$��
36,104,0,0q�A� -   $ btnAzul��
����  �$
��Left=�$��45��$	��Top=�$��36��$��
77,156,0,0q�A� -   $ 
btnAmarelo��
��� ���$
��Left=�$��45��$	��Top=�$��36��$��132,177,0,0q�A� -   $ btnPreto��
���   �$
��Left=�$��45��$	��Top=�$��36��$��182,140,0,0q�� $��260,134,10,10q�.+�A� -   $ demoball��$	��100��$	��100��
�������$��Center=�$��Center=��� -    ��Name$ minusopacidade��$��Button��$
��Left=�$��
255,84,0,0q�$	��Top=�$��40��   btnMenuStyle#���   $��40����Z� ��Z� ���� $ Images/diminuir.png��$ UniformToFill=��� -   $ btnplusopacidade��$��Button��$
��Left=�$��
354,84,0,0q�$	��Top=�$��40��#���   $��40����Z� ��Z� ���� $ Images/aumentar.png��$ UniformToFill=��� -   $ minusespessura��$��Button��$
��Left=�$��
255,37,0,0q�$	��Top=�$��40��#���   $��40����Z� ��Z� ���� $ Images/diminuir.png��$ UniformToFill=��� -   $ btnplusespessura��$��Button��$
��Left=�$��
354,37,0,0q�$	��Top=�$��40��#���   $��40����Z� ��Z� ���� $ Images/aumentar.png��$ UniformToFill=�