   M S B A M L   `   `   `  ����
  TETRIS    TETRIS.StatisticsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Статистика��5   	   $	��300��6   $	��400��6)    � Icon$ Assests/image/Icon.ico��5   	    � 	Resources 5
      &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  '        '  �    �� 5   
   "  6   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 0q�60   �� 5        �@ AlternatingRowBackground �	#FFE8E8E869   �� 5       �@ GridLinesVisibility$
 None=�64   �� 5       �@ HeadersVisibility$ Column=�62   �� 5       �@ 	RowHeight$ 30Q�6*   �� 5       � ��$ 14(�6)   �� 5        �@ HorizontalGridLinesBrush �	#FFD6D6D669   �� 5       �@ VerticalGridLinesBrush �	#FFD6D6D667   �� 5       �@ SelectionMode$ Single=�6.   �� 5!       �@ CanUserResizeRows .  62   �� 5#       �@ CanUserReorderColumns .  66   �� 5%       �@ CanUserSortColumns .  63   �� 5'       �@ 
IsReadOnly . 6+   �� 5)       �@ AutoGenerateColumns .  64   �� 5+      % �@ HorizontalScrollBarVisibility$
 Auto=�6>   �� 5-      # �@ VerticalScrollBarVisibility$
 Auto=�6<   5.      �� 51   
   "  6   .�53      ��  � �� �	#FFE8E8E86+   �� 55       � ��$ 1,1,1,1q�60   �� 57       � �� �	#FFD6D6D66,   �� 59       � ��$ 6q�6(   �� 5;       � ��$ Center=�6;   �� 5=       � ��$
 Bold"�6+   5>      5?      .��5B      � ��5D   
   �� 5E       �� ImageSource$" Assests/image/Background.jpg��6    j� Stretch$ UniformToFill=�6D   .+�5I   
     -   5          Name$ StatisticsDataGrid��5I      	   AutoGenerateColumns	 .  $��10,10,145,38q�6K   
������ 
 J� IsHitTestVisible
 .   J� RenderTransformOrigin$ 0.5,0.5&�6�    5K      *  $System.Windows.Controls.DataGridCell��%w   '        �� 5L      "  6   .�5N      ��  � ��
 ���� 63   �� 5P       � ��$ 0q�68   5Q      5R         Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn   Header$% Имя пользователя��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *
Username+  5Y      $ Очки��6%    63   �� *Score+5[      �� 5^   
   -   5         ��Name$ CancelButton��5^      $��Отмена��6'   $��307,0,10,10q�6S   $��Center=�6h   $��Bottom=�6�   $��75��6�   $��25��6�   
������6�   5_      5`      