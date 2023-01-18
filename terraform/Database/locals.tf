locals {
  common_tags = {
    company      = var.company
    project      = "${var.company}-${var.project}"
    billing_code = var.billing_code
    environment  = terraform.workspace
  }

  database_indentifier = lower("addressbookdb-${terraform.workspace}")
}