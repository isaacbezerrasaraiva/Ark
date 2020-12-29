echo "" >> /etc/samba/smb.conf
echo "[Ark]" >> /etc/samba/smb.conf
echo "comment = Ark" >> /etc/samba/smb.conf
echo "path = /home/ark" >> /etc/samba/smb.conf
echo "read only = no" >> /etc/samba/smb.conf
echo "browseable = yes" >> /etc/samba/smb.conf
echo "writeable = yes" >> /etc/samba/smb.conf

smbpasswd -a ark

systemctl restart smbd.service
