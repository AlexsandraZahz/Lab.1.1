   M S B A M L   `   `   `  ����A  =TETRIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TETRISTETRIS  5   	   &     TETRIS.DifficultySelectionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:TETRIS     5   	     � Title$0  *Выбор уровня сложности��5	   	   $	��200��6(   $	��400��65    � 
ResizeMode$ NoResize=�6A    � Icon$ Assests/image/Icon.ico��5
   	   .��5      � $��0,0,-6,0q�6   ��5   
   �� 5       �� ImageSource$" Assests/image/Background.jpg��6    j� Stretch$ UniformToFill=�6D    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ DifficultyComboBox��5      $��0��5      $��20q�5      $��Stretch=�5       $��Center=�5!      .@�5$      �� $��
Легко��6   �� 5%      $��Средне��6   �� 5&      $��Сложно��6   5'      �� 5*   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��	0,0,20,20q�6W   .+�5,      �� -   5         ��Name$ CancelButton��5,      $��Отмена��6+   $��5,0,5,5q�6W   
������$��63��6�   �� 5.      -   5        $ OkButton��5.      $��Выбрать��6'   $��5,0,5,5q�6P   
������$��66��6y   5/      50      51      