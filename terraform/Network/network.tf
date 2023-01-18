##################################################################################
# DATA
##################################################################################

data "aws_availability_zones" "available" {}

##################################################################################
# RESOURCES
##################################################################################

resource "aws_vpc" "addressbookvpc" {
  cidr_block = "10.0.0.0/22"
}

resource "aws_subnet" "addressbooksubnet1" {
  vpc_id            = aws_vpc.addressbookvpc.id
  cidr_block        = "10.0.1.0/24"
  availability_zone = data.aws_availability_zones.available.names[0]
}

resource "aws_subnet" "addressbooksubnet2" {
  vpc_id            = aws_vpc.addressbookvpc.id
  cidr_block        = "10.0.2.0/24"
  availability_zone = data.aws_availability_zones.available.names[1]
}

resource "aws_subnet" "addressbooksubnet3" {
  vpc_id            = aws_vpc.addressbookvpc.id
  cidr_block        = "10.0.3.0/24"
  availability_zone = data.aws_availability_zones.available.names[2]
}

resource "aws_db_subnet_group" "addressbooksubnetgroup" {
  name       = "addressbooksubnetgroup"
  subnet_ids = [aws_subnet.addressbooksubnet1.id, aws_subnet.addressbooksubnet2.id, aws_subnet.addressbooksubnet3.id]
}