f = open('frames_raw.txt')
c = 1
print('Frame ' + str(c) + ':')
xc = 0

for z in f:
	x = z.replace('[', '').replace(']', '').replace(',', '').replace(' ', '').replace('\n', '')
	if len(z) <= 1:
		print('__________________________________________________', '\n')
		c+=1
		xc=0
		print('Frame ' + str(c) + ':')
	elif z[0] == '_':
		print(z)
		xc=0
	else:
		l = ''
		yc = 0
		for y in x:
			if xc == int(len(x)/2) and yc == int(len(x)/2):
				l += 'X'
			elif y == '0':
				l += ' '
			else:
				l += y
			yc+=1
		print(l)
	xc+=1