##################################################################################
# VARIABLES
##################################################################################

variable "region" {
  default = "eu-west-2"
}

variable "engine" {
  type        = map(string)
  description = "SQL Server engine type"
}

variable "engine_version" {
  default = "15.00.4236.7.v1"
}

variable "instance_class" {
  type        = map(string)
  description = "AWS instance class"
}

variable "multi_az" {
  type = map(bool)
}

variable "replica_instance_count" {
  type = map(number)
}

variable "company" {
  type        = string
  description = "Company name for resource tagging"
  default     = "DG-Systems"
}

variable "project" {
  type        = string
  description = "Project name for resource tagging"
}

variable "billing_code" {
  type        = string
  description = "Billing code for resource tagging"
}