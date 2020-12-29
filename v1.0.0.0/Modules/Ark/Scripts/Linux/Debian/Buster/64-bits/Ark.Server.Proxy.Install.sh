echo "server {" > /etc/nginx/sites-available/ark
echo "  listen 80;" >> /etc/nginx/sites-available/ark
echo "  root /home/ark/v1.0.0.0/Release;" >> /etc/nginx/sites-available/ark
echo "  location / {" >> /etc/nginx/sites-available/ark
echo "    proxy_pass http://127.0.0.1:9050;" >> /etc/nginx/sites-available/ark
echo "    proxy_http_version 1.1;" >> /etc/nginx/sites-available/ark
echo "    proxy_set_header Upgrade \$http_upgrade;" >> /etc/nginx/sites-available/ark
echo "    proxy_set_header Connection keep-alive;" >> /etc/nginx/sites-available/ark
echo "    proxy_set_header Host \$http_host;" >> /etc/nginx/sites-available/ark
echo "    proxy_cache_bypass \$http_upgrade;" >> /etc/nginx/sites-available/ark
echo "  }" >> /etc/nginx/sites-available/ark
echo "}" >> /etc/nginx/sites-available/ark
