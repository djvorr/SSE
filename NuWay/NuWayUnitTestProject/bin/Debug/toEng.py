import goslate

ret = []

for x in range(len(l)):
    ret.append(goslate.Goslate().translate(l[x], "en"))
