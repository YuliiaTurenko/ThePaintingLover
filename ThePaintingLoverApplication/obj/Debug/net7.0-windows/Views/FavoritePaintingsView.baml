   M S B A M L   `   `   `  ����V  RThePaintingLoverApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ThePaintingLoverApplication.Views!ThePaintingLoverApplication.Views  5      =    7ThePaintingLoverApplication.Views.FavoritePaintingsView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:ThePaintingLoverApplication.Views     5      .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $��80 �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Your favorite paintings��5       
  Header#��[  5      ���	#FF2D02505      �� 5   
   $��0��6   $��80��5      $��30��5      $��	Main Menu��5      $��14(�5      $��Medium"�5      ���	#FF2D0355
�������$��0q�5      $��Right=�5      $��0 8 30 0q�5      ��5      �� *OpenMainMenuCommand+5      �� 5!   
   $��1��6   $��
30 10 30 0q�6N   ��6$   �� *FavoritePaintings+��5"      �� 5#      .R�5$      �� 
��� ���$��2q�61   $��5q�6E   ._�5%      ��  �� Orientation$ Vertical=�6%   $��5q�6<   .+�5&      �� $	��300��6@   $	��300��6P   $
��auto��6_   $
��auto��6m   $��5q�6z   ��6$   �� *
FilePath+6z   �� 5'      $
��Bold"�6?   $��14(�6Q    �� TextAlignment$ Center=�6_   ���	#FF2D0250$
��Wrap=�6�   ��6(   �� *Title+6�   �� 5(      $ Center=�6E   ���	#FF2D0250$
��Wrap=�6s   ��6(   �� *
ArtistName+6s   �� 5)      $ Center=�6G   ���	#FF2D0250$
��Wrap=�6u   ��6(   �� *CreationYear+6u   �� 5*      $��Favorite��5+   !   $��54��5,   !   ���	#FF2D0355
���������5/   !   �� *#!DataContext.ToggleFavoriteCommand+ �� RelativeSource ��  �� AncestorType UserControl��50   !   �� 51      52      53      55      56      57      