f = open('frames_raw.txt')

for z in f:
	x = z.replace('[', '').replace(']', '').replace(',', '').replace(' ', '').replace('\n', '')
	if len(z) <= 1:
		print('__________________________________________________', '\n')
	elif z[0] == '_':
		print(z)
	else:
		print(x)