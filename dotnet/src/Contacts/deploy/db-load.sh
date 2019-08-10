#!/usr/bin/env bash

aws dynamodb create-table \
    --cli-input-json file://./deploy/contacts-table.json \
    --endpoint-url http://localhost:8000