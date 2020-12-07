
lat = 23.58#緯度
lon = 120.58#經度
#Add data file
filename = 'C:\\gdas1.mar13.w5'#輸入檔案位置，將會在同一個資料夾產生CSV
f = addfile(filename)

filename=''.join(reversed(filename))
filename=filename.replace('.','_',2)
filename=''.join(reversed(filename))

        
print filename
#Read data array
tag=['PRSS','MSLP','TPP6','UMOF','VMOF','SHTF','DSWF','RH2M','U10M','V10M','TO2M','TCLD','SHGT','CAPE','CINH','LISD','LIB4','PBLH','TMPS','CPP6','SOLM','CSNO','CICE','CFZR','CRAI','LHTF','LCLD','MCLD','HCLD']#,'HGTS','TEMP','UWND','VWND','WWND','RELH']這段被註解掉的標籤是含有第五維度(高度)的內容，目前只能無法讀出

#Output data file
ofn = filename+'.csv'
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
    #Interpolate to station
    #line = '%s,%.2f,%.2f' % (t.strftime('%Y-%m-%d_%H'), pblh_st, ws_st)
    of.write('%s'%(t.strftime('%Y/%m/%d_%H')))
    for s in tag:
        if s not in skip:
            of.write(',')
            of.write(str(f[s][i,:,:].interpn([lat,lon])))
    of.write('\n')
of.close()