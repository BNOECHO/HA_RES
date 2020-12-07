import math
lat = 23.69#緯度
lon = 120.19#經度
#Add data file
filename = 'E:\\HA\\gdas1.mar13.w5'#輸入檔案位置，將會在同一個資料夾產生CSV
f = addfile(filename)

#Read data array
#tag=['PRSS','MSLP','TPP6','UMOF','VMOF','SHTF','DSWF','RH2M','U10M','V10M','TO2M','TCLD','SHGT','CAPE','CINH','LISD','LIB4','PBLH','TMPS','CPP6','SOLM','CSNO','CICE','CFZR','CRAI','LHTF','LCLD','MCLD','HCLD']#,'HGTS','TEMP','UWND','VWND','WWND','RELH']這段被註解掉的標籤是含有第五維度(高度)的內容，目前只能無法讀出

#Output data file
ofn = filename+'_'+str(lat)+'_'+str(lon)+'WSWD.csv'
of = open(ofn, 'w')
of.write('time,U10M,V10M,WS(m/s),WD(deg)\n')
u=f['U10M'][:,:,:]
v=f['V10M'][:,:,:]
ws=sqrt(u*u+v*v)#精度過低



#Get time dimension number
tn = u.dimlen(0)
#Loop
for i in range(tn):
    t = f.gettime(i)
    of.write('%s'%(t.strftime('%Y/%m/%d_%H,')))
    of.write(str(u[i,:,:].interpn([lat,lon])))
    of.write(',')
    of.write(str(v[i,:,:].interpn([lat,lon])))
    of.write(',')
    U=u[i,:,:].interpn([lat,lon])
    V=v[i,:,:].interpn([lat,lon])
    UPOW2=U*U
    VPOW2=V*V
   
    of.write(str(sqrt(UPOW2+VPOW2)))
    of.write(',')

    WD=270-math.atan2(V,U)*180/math.pi
    if ((U==0) or (V==0)):
        WD=""
    if WD>=360:
        WD-=360
    of.write(str(WD))
    of.write('\n')
of.close()