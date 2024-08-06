package com.orderservice.repositories

import com.orderservice.models.Order
import org.springframework.data.jpa.repository.JpaRepository
import java.util.*

interface OrderRepository : JpaRepository<Order, UUID> {
}