   M S B A M L   `   `   `  ����V  RThePaintingLoverApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ThePaintingLoverApplication.Views!ThePaintingLoverApplication.Views  5      4    .ThePaintingLoverApplication.Views.MainMenuView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:ThePaintingLoverApplication.Views     5      .��5	      � 
���k���  � ColumnDefinitions  5
   
   �� 5      $	��220 �6   �� 5       � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      .+�5   
   �� $��The Painting Lover��6   $��Center=�5      $��Center=�5      
�������$��22(�5      $��Medium"�5      �� 5   
   $��1��6   ���	#FFF4F5B3.+�5      �� $��Artists��5         MainMenuButton#��[  5      ���	#FF2D0250���	#FFF4F5B3��5      �� *ShowListOfArtistsCommand+5!      �� 5"      $��Styles��5#      #��[  5$      ���	#FF2D0355���	#FFF4F5B3��5%      �� *ShowListOfStylesCommand+5'      �� 5(      $��Favorite Paintings��5)      #��[  5*      ���	#FF2D0355���	#FFF4F5B3��5+      �� *ShowFavoritePaintingsCommand+5-      �� 5.      $��My Notes��5/      #��[  50      ���	#FF2D0355���	#FFF4F5B3��51      �� *ShowNotesCommand+53      �� 54      $��Change password��55      $��90��56      $��10(�57      ���	#FF2D0355
������ $��0q�5:      $��0 90 0 0q�5;      ��5<      �� *ChangePasswordCommand+5=      �� 5?   
   $��1��6   $	��300��5@      $��30��5A      $��12(�5B      $��Center=�5C      $
��Left=�5D      $��20q�5E       �� 	MaxLength$ 50��5F      
���������5H      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=��� 5J   
   $��0��6   $��1��6   $��80��5K      $��30��5L      $��Search��5M      $��14(�5N      $��Medium"�5O      ���	#FF2D0355
�������$��0q�5S      $
��Left=�5T      $��	330 0 0 0q�5U      ��5P      �� *SearchCommand+5U      �� 5W   
   $��1��6   $��1��6   
�������$��0q�5Y      ��5Z      �� *SearchResults+ �� SelectedItem 5[      �� *SelectedResult+��5\      �� 5]      .R�5^      �� $��16(�61   $��Medium"�6?   ���	#FF2D0355$��6q�6j   ��6    �� 6j   5_      5a      5b      5c      