
lat = 23.69#緯度
lon = 120.19#經度
#Add data file
filename = 'E:\\HA\\gdas1.mar13.w5'#輸入檔案位置，將會在同一個資料夾產生CSV
f = addfile(filename)


#Read data array
tag=['PRSS','MSLP','TPP6','UMOF','VMOF','SHTF','DSWF','RH2M','U10M','V10M','TO2M','TCLD','SHGT','CAPE','CINH','LISD','LIB4','PBLH','TMPS','CPP6','SOLM','CSNO','CICE','CFZR','CRAI','LHTF','LCLD','MCLD','HCLD']#,'HGTS','TEMP','UWND','VWND','WWND','RELH']這段被註解掉的標籤是含有第五維度(高度)的內容，目前只能無法讀出
ofn = filename+'_'+str(lat)+'_'+str(lon)+'ToCSV.csv'
#Output data file

of = open(ofn, 'w')
of.write('time')
skip=[]
for s in tag:
    var=f.dataset.getDataInfo().getVariable(s)
    if var is None:
        print 'ERR'+s
        skip.append(s)
    else:
        of.write(',')
        of.write(s)
        print s
of.write('\n')
#Get time dimension number
tn = f[tag[0]][:,:,:].dimlen(0)
#Loop
for i in range(tn):
    t = f.gettime(i)

    of.write('%s'%(t.strftime('%Y/%m/%d_%H')))
    for s in tag:
        if s not in skip:
            of.write(',')
            of.write(str(f[s][i,:,:].interpn([lat,lon])))
    of.write('\n')
of.close()