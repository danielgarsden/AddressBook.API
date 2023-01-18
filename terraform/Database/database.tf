
##################################################################################
# DATA
##################################################################################

data "aws_availability_zones" "available" {}

##################################################################################
# RESOURCES
##################################################################################

resource "aws_db_instance" "AddressBookDB" {
  allocated_storage       = "20"
  engine                  = var.engine[terraform.workspace]
  identifier              = local.database_indentifier
  engine_version          = var.engine_version
  instance_class          = var.instance_class[terraform.workspace]
  multi_az                = var.multi_az[terraform.workspace]
  backup_retention_period = 1
  username                = var.user_name
  password                = var.password
  skip_final_snapshot     = true
  publicly_accessible     = false
  license_model           = "license-included"
  db_subnet_group_name    = "addressbooksubnetgroup"

  tags = local.common_tags
}

resource "aws_db_instance" "AddressBookD_Breplica" {
  count                   = var.replica_instance_count[terraform.workspace]
  allocated_storage       = "20"
  engine                  = var.engine[terraform.workspace]
  identifier              = "addressbookdbreplica"
  engine_version          = var.engine_version
  instance_class          = var.instance_class[terraform.workspace]
  backup_retention_period = 1
  username                = var.user_name
  password                = var.password
  skip_final_snapshot     = true
  publicly_accessible     = false
  license_model           = "license-included"
  replicate_source_db     = aws_db_instance.AddressBookDB.identifier

  tags = local.common_tags
}