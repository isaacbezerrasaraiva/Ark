WORKING_DIR="$(pwd)"

echo "[Unit]" > /etc/systemd/system/Ark.Server.service
echo "Description=Ark.Server" >> /etc/systemd/system/Ark.Server.service
echo "" >> /etc/systemd/system/Ark.Server.service
echo "[Service]" >> /etc/systemd/system/Ark.Server.service
echo "WorkingDirectory=$WORKING_DIR" >> /etc/systemd/system/Ark.Server.service
echo "ExecStart=/usr/bin/dotnet $WORKING_DIR/Ark.Server.dll" >> /etc/systemd/system/Ark.Server.service
echo "Restart=always" >> /etc/systemd/system/Ark.Server.service
echo "RestartSec=10" >> /etc/systemd/system/Ark.Server.service
echo "SyslogIdentifier=Ark.Server" >> /etc/systemd/system/Ark.Server.service
echo "User=ark" >> /etc/systemd/system/Ark.Server.service
echo "Environment=ASPNETCORE_ENVIRONMENT=Production" >> /etc/systemd/system/Ark.Server.service
echo "" >> /etc/systemd/system/Ark.Server.service
echo "[Install]" >> /etc/systemd/system/Ark.Server.service
echo "WantedBy=multi-user.target" >> /etc/systemd/system/Ark.Server.service

systemctl enable Ark.Server.service
